using System;
using com.GE1Assignment.Path;
using UnityEditor;
using UnityEngine;

namespace com.GE1Assignment.Editor {

    [CustomEditor(typeof(PathCreator))]
    public class PathEditor : UnityEditor.Editor {

        private PathCreator _creator;
        private Path.Path _path;

        public override void OnInspectorGUI() {
            EditorGUI.BeginChangeCheck();
            
            if (GUILayout.Button("New Path")) {
                Undo.RecordObject(_creator, "Create New");
                _creator.CreatePath();
                _path = _creator.path;
            }
            
            if (GUILayout.Button("Toggle Closed")) {
                Undo.RecordObject(_creator, "Toggle Closed");
                _path.ToggleClosed();
                
            }

            bool autoSetControlPoints = GUILayout.Toggle(_path.AutoSetControlPoints, "Auto Set Control Points");
            if (autoSetControlPoints != _path.AutoSetControlPoints) {
                Undo.RecordObject(_creator, "Toggle Auto Set");
                _path.AutoSetControlPoints = autoSetControlPoints;
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

            _path = _creator.path;

        }
        
        private void OnSceneGUI() {
            Input();
            Draw();
        }

        void Input() {
            Event guiEvent = Event.current;
            Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift) {
                Undo.RecordObject(_creator, "Add Segment");
                _path.AddSegment(mousePos);
                
            }
            
        }
        
        private void Draw() {

            for (int i = 0; i < _path.NumSegments; i++) {
                var points = _path.GetPointsInSegment(i);
                Handles.color = Color.black;
                Handles.DrawLine(points[1], points[0]);
                Handles.DrawLine(points[2], points[3]);
                Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.green, null, 2);
            }
            
            Handles.color = Color.red;
            for (int i = 0; i < _path.NumPoints; i++) {
                Vector2 newPos = Handles.FreeMoveHandle(_path[i], Quaternion.identity, .1f, Vector3.zero, Handles.CylinderHandleCap);

                if (_path[i] != newPos) {
                    Undo.RecordObject(_creator, "Move Point");
                    _path.MovePoint(i, newPos);
                }
                
            }
        }

        

    }

}
