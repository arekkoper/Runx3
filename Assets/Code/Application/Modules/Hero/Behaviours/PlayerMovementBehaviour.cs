using UnityEngine;

namespace Code.Application.Modules.Hero.Behaviours
{
    public class PlayerMovementBehaviour
    {
        private Vector3 _movementVelocity;

        public CharacterController CharacterController { get; set; }
        public Transform Model { get; set; }
        public float Speed { get; set; }
        public float VelocityGain { get; set; }
        public float VelocityLoss { get; set; }
        public float ReverseMomentum { get; set; }
        public bool StopHandleInputs { get; set; }

        public PlayerMovementBehaviour()
        {
            _movementVelocity = Vector3.zero;
            StopHandleInputs = false;
        }

        public void Behave()
        {
            if(!StopHandleInputs)
            {
                HandleInputs();
            }
            else
            {
                if (_movementVelocity.z > 0)
                    _movementVelocity.z = Mathf.Max(0, _movementVelocity.z - VelocityLoss * Time.deltaTime);
                else
                    _movementVelocity.z = Mathf.Min(0, _movementVelocity.z + VelocityLoss * Time.deltaTime);

                if (_movementVelocity.x > 0)
                    _movementVelocity.x = Mathf.Max(0, _movementVelocity.x - VelocityLoss * Time.deltaTime);
                else
                    _movementVelocity.x = Mathf.Min(0, _movementVelocity.x + VelocityLoss * Time.deltaTime);

            }

            MovementLogic();
        }

        private void MovementLogic()
        {
            //Move
            if (_movementVelocity.x != 0 || _movementVelocity.z != 0)
            {
                CharacterController.Move(_movementVelocity * Time.deltaTime);
                Model.rotation = Quaternion.Slerp(Model.rotation, Quaternion.LookRotation(_movementVelocity), 0.18f);
            }
        }

        private void HandleInputs()
        {
            //Up & Down
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (_movementVelocity.z >= 0)
                    _movementVelocity.z = Mathf.Min(Speed, _movementVelocity.z + VelocityGain * Time.deltaTime);
                else
                    _movementVelocity.z = Mathf.Min(0, _movementVelocity.z + VelocityGain * ReverseMomentum * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (_movementVelocity.z > 0)
                    _movementVelocity.z = Mathf.Max(0, _movementVelocity.z - VelocityGain * ReverseMomentum * Time.deltaTime);
                else
                    _movementVelocity.z = Mathf.Max(-Speed, _movementVelocity.z - VelocityGain * Time.deltaTime);
            }
            else
            {
                if (_movementVelocity.z > 0)
                    _movementVelocity.z = Mathf.Max(0, _movementVelocity.z - VelocityLoss * Time.deltaTime);
                else
                    _movementVelocity.z = Mathf.Min(0, _movementVelocity.z + VelocityLoss * Time.deltaTime);
            }

            //Left & Right
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (_movementVelocity.x >= 0)
                    _movementVelocity.x = Mathf.Min(Speed, _movementVelocity.x + VelocityGain * Time.deltaTime);
                else
                    _movementVelocity.x = Mathf.Min(0, _movementVelocity.x + VelocityGain * ReverseMomentum * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (_movementVelocity.x > 0)
                    _movementVelocity.x = Mathf.Max(0, _movementVelocity.x - VelocityGain * ReverseMomentum * Time.deltaTime);
                else
                    _movementVelocity.x = Mathf.Max(-Speed, _movementVelocity.x - VelocityGain * Time.deltaTime);
            }
            else
            {
                if (_movementVelocity.x > 0)
                    _movementVelocity.x = Mathf.Max(0, _movementVelocity.x - VelocityLoss * Time.deltaTime);
                else
                    _movementVelocity.x = Mathf.Min(0, _movementVelocity.x + VelocityLoss * Time.deltaTime);
            }
        }
    }
}