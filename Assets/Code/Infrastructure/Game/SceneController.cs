
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Infrastructure
{
    public class SceneController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Configuration")]
        [SerializeField] private float _duration;

        [Header("Parameters")]
        [SerializeField] private float _counter;

        [Header("Dependencies")]
        [SerializeField] private GameManager _gameManager;


        private void Awake()
        {
            _gameManager.OnStateChange += GameManager_OnStateChange;
        }

        private void GameManager_OnStateChange()
        {
            StartCoroutine(Transition());
        }

        public IEnumerator Transition()
        {
            _canvasGroup.blocksRaycasts = true;

            _counter = 0f;
            while (_counter < _duration)
            {
                _counter += Time.deltaTime;
                _canvasGroup.alpha = _counter / _duration;
                yield return new WaitForEndOfFrame();
            }

            _gameManager.CurrentState.ScenesToUnload.ForEach(scene =>
            {
                if (SceneManager.GetSceneByName(scene).isLoaded) SceneManager.UnloadSceneAsync(scene);
            });

            var asyncOperations = new List<AsyncOperation>();
            _gameManager.CurrentState.ScenesToLoad.ForEach(scene => asyncOperations.Add(SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive)));

            var asyncLoaded = new List<AsyncOperation>();
            while (asyncLoaded.Count != asyncOperations.Count)
            {
                asyncOperations.ForEach(async =>
                {
                    if (async.isDone && !asyncLoaded.Contains(async)) asyncLoaded.Add(async);
                });

                yield return null;
            }

            while (_counter > 0f)
            {
                _counter -= Time.deltaTime;
                _canvasGroup.alpha = _counter / _duration;
                yield return new WaitForEndOfFrame();
            }

            _canvasGroup.blocksRaycasts = false;
        }

    }
}