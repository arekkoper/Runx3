using System;
using System.Collections;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Spawners;
using Code.Application.Signals;
using Code.Presentation.Presenters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class DashController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Slider dashSlider;
        [SerializeField] private Image dashIcon;
        [SerializeField] private Color ongoingColor;
        [SerializeField] private Color readyColor;

        [Inject] private readonly IPlayerSpawner _spawner;
        [Inject] private readonly SignalBus _signalBus;

        private PlayerPresenter _presenter;

        private void Start()
        {
            Restart();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerKilledSignal>(Restart);
            _signalBus.Subscribe<OnPlayerDashSignal>(Refresh);
            _signalBus.Subscribe<OnLevelLoadedSignal>(Restart);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(Restart);
            _signalBus.Unsubscribe<OnPlayerDashSignal>(Refresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Restart);
        }

        private void Refresh()
        {
            if (!_presenter) _presenter = _spawner.GetPresenter();
            
            StartCoroutine(RefreshSlider());
        }

        private IEnumerator RefreshSlider()
        {
            dashIcon.color = ongoingColor;
            
            while (!_presenter.DashBehaviour.CanDashNow)
            {
                dashSlider.value = (_presenter.DashBehaviour.DashCooldown - _presenter.DashBehaviour.Cooldown) / _presenter.DashBehaviour.DashCooldown;
                yield return new WaitForEndOfFrame();
            }

            dashIcon.color = readyColor;
        }
        
        private void Restart()
        {
            StopAllCoroutines();
            dashSlider.value = 1;
            dashIcon.color = readyColor;
        }
    }
}