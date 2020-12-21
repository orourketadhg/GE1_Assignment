using System;
using com.GE1Assignment.Path;
using UnityEditor;
using UnityEngine;

namespace com.GE1Assignment.Editor {

    [CustomEditor(typeof(PathCreator))]
    public class PathEditor : UnityEditor.Editor {

        private PathCreator _creator;

        private Path.Path Path => _creator.path;

        private const float SelectThreshold = 0.1f;
        private int _selectedSegmentIndex = -1;

        public override void OnInspectorGUI() {
            EditorGUI.BeginChangeCheck();
            
            if (GUILayout.Button("New Path")) {
                Undo.RecordObject(_creator, "Create New");
                _creator.CreatePath();
            }

            bool toggleClosed = GUILayout.Toggle(Path.IsClosed, "Toggle Closed");
            if (toggleClosed != Path.IsClosed) {
                Undo.RecordObject(_creator, "Toggle Closed");
                Path.IsClosed = toggleClosed;

            }

            bool autoSetControlPoints = GUILayout.Toggle(Path.AutoSetControlPoints, "Auto Set Control Points");
            if (autoSetControlPoints != Path.AutoSetControlPoints) {
                Undo.RecordObject(_creator, "Toggle Auto Set");
                Path.AutoSetControlPoints = autoSetControlPoints;
            }

            if (EditorGUI.EndChangeCheck()) {
                SceneView.RepaintAll();
            }
            
        }

        private void OnEnable() {
            _creator = (PathCreator) target;

            if (_creator.path == null) {
                _creator.CreatePath();
            }
            
        }
        
        private void OnSceneGUI() {
            Input();
            Draw();
        }

        void Input() {
            Event guiEvent = Event.current;
            Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift) {
                if (_selectedSegmentIndex != -1) {
                    Undo.RecordObject(_creator, "Add Segment");
                    Path.SplitSegment(mousePos, _selectedSegmentIndex);
                }
                else if (!Path.IsClosed){
                    Undo.RecordObject(_creator, "Add Segment");
                    Path.AddSegment(mousePos);
                }
            }

            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 1) {
                float minDistanceToAnchor = .05f;
                int closestAnchorIndex = -1;

                for (int i = 0; i < Path.NumPoints; i += 3) {
                    float dst = Vector2.Distance(mousePos, Path[i]);
                    if (dst < minDistanceToAnchor) {
                        dst = minDistanceToAnchor;
                        closestAnchorIndex = i;
                    }
                }

                if (closestAnchorIndex != -1) {
                    Undo.RecordObject(_creator, "Delete Segment");
                    Path.DeleteSegment(closestAnchorIndex);
                }
                
            }

            if (guiEvent.type == EventType.MouseMove) {
                float minDstToSegment = SelectThreshold;
                int newSelectedSegmentIndex = -1;

                for (int i = 0; i < Path.NumSegments; i++) {
                    var points = Path.GetPointsInSegment(i);
                    float dst = HandleUtility.DistancePointBezier(mousePos, points[0], points[3], points[1], points[2]);
                    if (dst < minDstToSegment) {
                        minDstToSegment = dst;
                        newSelectedSegmentIndex = i;
                    }
                }

                if (newSelectedSegmentIndex != _selectedSegmentIndex) {
                    _selectedSegmentIndex = newSelectedSegmentIndex;
                    HandleUtility.Repaint();
                }
            }

        }
        
        private void Draw() {

            for (int i = 0; i < Path.NumSegments; i++) {
                var points = Path.GetPointsInSegment(i);
                Handles.color = Color.black;
                Handles.DrawLine(points[1], points[0]);
                Handles.DrawLine(points[2], points[3]);

                Color segmentColor = ( i == _selectedSegmentIndex && Event.current.shift ) ? Color.red : Color.green;
                
                Handles.DrawBezier(points[0], points[3], points[1], points[2], segmentColor, null, 2);
            }
            
            Handles.color = Color.red;
            for (int i = 0; i < Path.NumPoints; i++) {
                Vector2 newPos = Handles.FreeMoveHandle(Path[i], Quaternion.identity, .1f, Vector3.zero, Handles.CylinderHandleCap);

                if (Path[i] != newPos) {
                    Undo.RecordObject(_creator, "Move Point");
                    Path.MovePoint(i, newPos);
                }
                
            }
        }

        

    }

}
