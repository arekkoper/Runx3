
using Assets.Code.Presentation.Presenters;
using log4net.Util;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure.Editor
{
    [CustomEditor(typeof(ShooterPresenter))]
    public class ShooterRangeViewerEditor : UnityEditor.Editor
    {
        private ShooterPresenter Target { get { return (ShooterPresenter)target; } }

        private void OnSceneGUI()
        {
            var start = Vector3.zero;
            var end = Vector3.forward * Target.Range;
            var rotation = Target.transform.rotation;

            start = rotation * start + Target.transform.position + Vector3.up * 2.8f;
            end = rotation * end + Target.transform.position + Vector3.up * 2.8f;
            
            Handles.color = Color.red;
            Handles.DrawLine(start, end);
        }
    }
}