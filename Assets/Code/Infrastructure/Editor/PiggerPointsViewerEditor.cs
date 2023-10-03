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

            Debug.Log("Ohayoo!");

        }
    }
}