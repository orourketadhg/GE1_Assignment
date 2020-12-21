﻿using System.Collections.Generic;
using com.GE1Assignment.Mathematics;
using UnityEngine;

namespace com.GE1Assignment.Path {

    [System.Serializable]
    public class Path {

        [SerializeField, HideInInspector] private List<Vector2> points;
        [SerializeField, HideInInspector] private bool isClosed;
        [SerializeField, HideInInspector] private bool autoSetControlPoints;

        public Path(Vector2 centre) {
            points = new List<Vector2>() {
                centre + Vector2.left,
                centre + ( Vector2.left + Vector2.up ) * 0.5f,
                centre + ( Vector2.right + Vector2.down ) * 0.5f,
                centre + Vector2.right
            };
        }

        public Vector2 this[int i] => ( points[i] );

        public bool AutoSetControlPoints {
            get => autoSetControlPoints;
            set {
                if (autoSetControlPoints != value) {
                    autoSetControlPoints = value;
                    if (autoSetControlPoints) {
                        AutoSetAllControlPoints();
                    }
                }
            }
        }

        public int NumPoints => ( points.Count );
    
        public int NumSegments => points.Count / 3;
        public bool IsClosed {
            get => isClosed;
            set {
                if (isClosed != value) {
                    isClosed = value;
                    
                    if (isClosed) {
                        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
                        points.Add(points[0] * 2 - points[1]);
                        if (autoSetControlPoints) {
                            AutoSetAnchorControlPoints(0);
                            AutoSetAnchorControlPoints(points.Count - 3);
                        }
                    }
                    else {
                        points.RemoveRange(points.Count - 2, 2);
                        if (autoSetControlPoints) {
                            AutoSetStartAndEndControls();
                        }
                    }
                    
                }
            }
        }

        public void AddSegment(Vector2 anchorPosition) {
            points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
            points.Add((points[points.Count - 1] + anchorPosition) * 0.5f);
            points.Add(anchorPosition);

            if (autoSetControlPoints) {
                AutoSetAllAffectedControlPoints(points.Count - 1);
            }
        }

        public void SplitSegment(Vector2 anchorPosition, int index) {
            points.InsertRange(index*3+2, new[] {
                Vector2.zero, anchorPosition, Vector2.zero
            });

            if (autoSetControlPoints) {
                AutoSetAllAffectedControlPoints(index * 3 + 3);
            }
            else {
                AutoSetAnchorControlPoints(index * 3 + 3);
            }
        }

        public void DeleteSegment(int anchorIndex) {
            if (NumSegments > 2 || !isClosed && NumSegments > 1) {

                if (anchorIndex == 0) {
                    if (isClosed) {
                        points[points.Count - 1] = points[2];
                    }

                    points.RemoveRange(0, 3);
                }
                else if (anchorIndex == points.Count - 1 && !isClosed) {
                    points.RemoveRange(anchorIndex - 2, 3);
                }
                else {
                    points.RemoveRange(anchorIndex - 1, 3);
                }
            }
        }

        public Vector2[] GetPointsInSegment(int index) {
            return new[] {points[index * 3], points[index * 3 + 1], points[index * 3 + 2], points[LoopIndex(index * 3 + 3)]};
        }

        public void MovePoint(int index, Vector2 newPosition) {

            Vector2 deltaMove = newPosition - points[index];
            if (index % 3 == 0 || !autoSetControlPoints) {
                points[index] = newPosition;

                if (autoSetControlPoints) {
                    AutoSetAllAffectedControlPoints(index);
                }
                else {

                    if (index % 3 == 0) {

                        if (index + 1 < points.Count || isClosed) {
                            points[LoopIndex(index + 1)] += deltaMove;
                        }

                        if (index - 1 >= 0 || isClosed) {
                            points[LoopIndex(index - 1)] += deltaMove;
                        }
                    }
                    else {
                        bool nextPointIsAnchor = ( index + 1 ) % 3 == 0;
                        int correspondingControlIndex = ( nextPointIsAnchor ) ? index + 2 : index - 2;
                        int anchorIndex = ( nextPointIsAnchor ) ? index + 1 : index - 1;

                        if (correspondingControlIndex >= 0 && correspondingControlIndex < points.Count || isClosed) {

                            float dst =
                                ( points[LoopIndex(anchorIndex)] - points[LoopIndex(correspondingControlIndex)] )
                                .magnitude;
                            Vector2 dir = ( points[LoopIndex(anchorIndex)] - newPosition ).normalized;
                            points[LoopIndex(correspondingControlIndex)] = points[LoopIndex(anchorIndex)] + dir * dst;

                        }

                    }

                }
                
            }

        }

        public Vector2[] CalculateEvenlySpacedPoints(float spacing, float resolution = 1) {
            var evenlySpacedPoints = new List<Vector2> {points[0]};
            Vector2 previousPoint = points[0];
            float dstSinceLastEvenPoint = 0;

            for (int i = 0; i < NumSegments; i++) {
                var p = GetPointsInSegment(i);
                float controlNetLength = Vector2.Distance(p[0], p[1]) + Vector2.Distance(p[1], p[2]) + Vector2.Distance(p[2], p[3]);
                float estCurveLength = Vector2.Distance(p[0], p[3]) + controlNetLength * 0.5f;
                int numDivisions = Mathf.CeilToInt(estCurveLength * resolution * 10);
                float t = 0;
                
                while (t <= 1) {
                    t += 1f/numDivisions;
                    Vector2 pointOnCurve = Bezier.Vector2CubicCurve(p[0], p[1], p[2], p[3], t);
                    dstSinceLastEvenPoint += Vector2.Distance(previousPoint, pointOnCurve);

                    while (dstSinceLastEvenPoint >= spacing) {
                        float overshootDst = dstSinceLastEvenPoint - spacing;
                        Vector2 newPoint = pointOnCurve + ( previousPoint - pointOnCurve ).normalized * overshootDst;
                        evenlySpacedPoints.Add(newPoint);
                        dstSinceLastEvenPoint = overshootDst;
                        previousPoint = newPoint;
                    }
                    
                    previousPoint = pointOnCurve;
                    
                }
            }

            return evenlySpacedPoints.ToArray();

        }

        private void AutoSetAllAffectedControlPoints(int updatedAnchorIndex) {
            for (int i = updatedAnchorIndex - 3; i <= updatedAnchorIndex + 3; i += 3) {
                if (i >= 0 && i < points.Count || isClosed) {
                    AutoSetAnchorControlPoints(LoopIndex(i));
                }
            }
            
            AutoSetAllControlPoints();
        }

        private void AutoSetAllControlPoints() {
            for (int i = 0; i < points.Count; i+= 3) {
                AutoSetAnchorControlPoints(i);
            }
            
            AutoSetStartAndEndControls();
        }

        private void AutoSetAnchorControlPoints(int anchorIndex) {
            Vector2 anchorPos = points[anchorIndex];
            Vector2 dir = Vector2.zero;
            float[] neighbourDistances = new float[2];

            if (anchorIndex - 3 >= 0 || isClosed) {
                Vector2 offset = points[LoopIndex(anchorIndex - 3)] - anchorPos;
                dir += offset.normalized;
                neighbourDistances[0] = offset.magnitude;
            }
            
            if (anchorIndex + 3 >= 0 || isClosed) {
                Vector2 offset = points[LoopIndex(anchorIndex + 3)] - anchorPos;
                dir -= offset.normalized;
                neighbourDistances[1] = -offset.magnitude;
            }

            dir.Normalize();
            
            for (int i = 0; i < 2; i++) {
                int controlIndex = anchorIndex + i * 2 - 1;
                if (controlIndex >= 0 && controlIndex < points.Count || isClosed) {
                    points[LoopIndex(controlIndex)] = anchorPos + dir * (neighbourDistances[i] * 0.5f);
                }
            }

        }

        private void AutoSetStartAndEndControls() {
            if (!isClosed) {
                points[1] = ( points[0] + points[2] ) * 0.5f;
                points[points.Count - 2] = ( points[points.Count - 1] + points[points.Count - 3] ) * 0.5f;
            }
        }

        private int LoopIndex(int i) {
            return ( i + points.Count ) % points.Count;
        }
    
    }

}
