using System.Collections;
using Code.Presentation.Commons.Abstractions;
using Code.Presentation.Views;
using UnityEngine;

namespace Code.Presentation.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private HomeView _homeView;
        [SerializeField] private LevelsView _levelsView;

        [Header("Settings")]
        [SerializeField] private View _initialView;

        private View _previousView;
        private View _currentView;
        private float _counter;
        private float _duration;

        private void Start()
        {
            _counter = 0f;
            _duration = 0.3f;
            _previousView = _initialView;
        }

        public void ShowHomeView()
        {
            Show(_homeView);
        }

        public void ShowLevelsView()
        {
            _levelsView.LevelId = 1;
            Show(_levelsView);
        }

        public void Show(View view)
        {
            StartCoroutine(Transition(view));
        }

        private IEnumerator Transition(View view)
        {
            _currentView = view;

            _previousView.CanvasGroup.interactable = false;
            _counter = _duration;
            while (_counter > 0f)
            {
                _counter -= Time.deltaTime;
                _previousView.CanvasGroup.alpha = _counter / _duration;
                yield return new WaitForEndOfFrame();
            }

            _currentView.CanvasGroup.interactable = true;
            _currentView.Refresh();
            while (_counter < _duration)
            {
                _counter += Time.deltaTime;
                _currentView.CanvasGroup.alpha = _counter / _duration;
                yield return new WaitForEndOfFrame();
            }

            _previousView = _currentView;
        }
    }
}