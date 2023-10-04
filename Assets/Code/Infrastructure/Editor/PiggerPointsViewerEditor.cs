#if UNITY_EDITOR
using Assets.Code.Presentation.Presenters;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure.Editor
{
    [CustomEditor(typeof(PiggerPresenter))]
    public class PiggerPointsViewerEditor : UnityEditor.Editor
    {
        private PiggerPresenter Target { get { return (PiggerPresenter)target; } }
        private List<Transform> _points = new List<Transform>();

        private void OnEnable()
        {
            _points = Target.GetUnsortedPatrolPoints();
        }

        private void OnSceneGUI()
        {
            Handles.color = Color.yellow;

            if(_points != null && _points.Count > 1)
            {
                for(int i = 0; i < _points.Count; i++)
                {
                    var point = _points[i].position;
                    Handles.Label(point, $"Point {i}");
                    Handles.DrawWireCube(point, Vector3.one * 0.2f);

                    if(i < _points.Count - 1)
                    {
                        var nextPoint = _points[i + 1].position;
                        Handles.DrawLine(point, nextPoint);
                    }
                    else if(i == _points.Count - 1 && _points.Count > 2)
                    {
                        var firstPoint = _points[0].position;
                        Handles.DrawLine(point, firstPoint);
                    }
                }
            }

        }
    }
}
#endif