using Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Code.Application.Modules.Hero.Behaviours
{
    public class PlayerDashBehaviour
    {
        public CharacterController CharacterController { get; set; }
        public Vector3 MovementVelocity { get; set; }
        public Transform Model { get; set; }
        public float Speed { get; set; }
        public SignalBus SignalBus { get; set; }
        
        private Vector3 _dashDirection;
        private float _dashDistance = 10f;
        private float _dashTime = 0.18f;
        private float _dashCooldown = 3f;
        private float _dashBeginTime = Mathf.NegativeInfinity;
        
        public bool CanDashNow => Time.time > _dashBeginTime + _dashTime + _dashCooldown;
        public float Cooldown => _dashBeginTime + _dashTime + _dashCooldown - Time.time;
        public float DashCooldown => _dashCooldown + _dashTime;
        public bool IsDashing => Time.time < _dashBeginTime + _dashTime;

        public void Behave()
        {
            if (!IsDashing && CanDashNow)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    var movementDir = Vector3.zero;

                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                        movementDir.z = 1;
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                        movementDir.z = -1;

                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        movementDir.x = 1;
                    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                        movementDir.x = -1;

                    if (movementDir.x != 0 || movementDir.z != 0)
                    {
                        _dashDirection = movementDir;
                        _dashBeginTime = Time.time;
                        MovementVelocity = _dashDirection * Speed;
                        Model.forward = _dashDirection;
                    }
                    
                    SignalBus.Fire(new OnPlayerDashSignal());
                }
            }

            if (IsDashing)
            {
                CharacterController.Move(_dashDirection * (_dashDistance / _dashTime) * Time.deltaTime);
            }
        }
    }
}