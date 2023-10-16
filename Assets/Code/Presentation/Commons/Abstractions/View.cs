using UnityEngine;

namespace Assets.Code.Presentation.Commons.Interfaces
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
