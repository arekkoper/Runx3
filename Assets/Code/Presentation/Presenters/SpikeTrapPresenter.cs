using Assets.Code.Presentation.Commons;
using UnityEngine;

namespace Assets.Code.Presentation.Presenters
{
    public class SpikeTrapPresenter : MonoStatic
    {
        [Header("References")]
        [SerializeField] private Transform _spikeHolder;
        [SerializeField] private GameObject _hitBoxObject;
        [SerializeField] private GameObject _colliderObject;

        [Header("Parameters")]
        [SerializeField] private float _interval;
        [SerializeField] private float _raiseWaitTime;
        [SerializeField] private float _lowerTime;
        [SerializeField] private float _raiseTime;

        private enum State
        {
            Lowered,
            Lowering,
            Raising,
            Raised
        }

        private State _state = State.Lowered;
        private const float SpikeWeight = 3.6f;
        private const float LoweredSpikeHeight = 0.88f;
        private float _lastSwitchTime = Mathf.NegativeInfinity;

        private void Start()
        {
            Invoke("StartRising", _interval);
        }

        private void StartRising()
        {
            _hitBoxObject.SetActive(true);
            _lastSwitchTime = Time.time;
            _state = State.Raising;
        }

        private void StartLowering()
        {
            _hitBoxObject.SetActive(false);
            _lastSwitchTime = Time.time;
            _state = State.Lowering;
        }

        private void Update()
        {
            Moving();
        }

        private void Moving()
        {
            if(_state == State.Lowering)
            {
                var scale = _spikeHolder.localScale;

                scale.y = Mathf.Lerp(SpikeWeight, LoweredSpikeHeight, (Time.time - _lastSwitchTime) / _lowerTime);
                _spikeHolder.localScale = scale;

                if(scale.y == LoweredSpikeHeight)
                {
                    Invoke("StartRising", _interval);
                    _colliderObject.SetActive(false);
                    _state = State.Lowered;
                }
            }
            else if(_state == State.Raising)
            {
                var scale = _spikeHolder.localScale;

                scale.y = Mathf.Lerp(LoweredSpikeHeight, SpikeWeight, (Time.time - _lastSwitchTime) / _raiseTime);
                _spikeHolder.localScale = scale;

                if (scale.y == SpikeWeight)
                {
                    Invoke("StartLowering", _raiseWaitTime);
                    _colliderObject.SetActive(true);
                    _state = State.Raised;
                }

            }
        }
    }
}