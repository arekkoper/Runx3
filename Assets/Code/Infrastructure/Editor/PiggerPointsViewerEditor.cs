using Assets.Code.Presentation.Presenters;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure.Editor
{
    [CustomEditor(typeof(PiggerPresenter))]
    public class PiggerPointsViewerEditor : UnityEditor.Editor
    {
        private PiggerPresenter Target { get { return (PiggerPresenter)target; } }

        private void OnSceneGUI()
        {
            if (Target == null) return;

            Handles.color = Color.white;

            Vector3[] vectors = new Vector3[Target.Points.Length];

            for (int i = 0; i < Target.Points.Length; i++)
            {
                vectors[i] = Target.Points[i].position;
            }

            Handles.DrawLines(vectors);

        }
    }
}