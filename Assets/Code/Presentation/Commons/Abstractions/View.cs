using UnityEngine;

namespace Code.Presentation.Commons.Abstractions
{
    public abstract class View : MonoStatic
    {
        private CanvasGroup _canvasGroup;

        public CanvasGroup CanvasGroup { get => _canvasGroup; }

        protected override void Awake()
        {
            base.Awake();

            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public abstract void Refresh(); //refresh data
    }
}
