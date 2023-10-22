using UnityEngine;

namespace Code.Application.Modules.Hero.Behaviours
{
    public class PlayerMovementBehaviour
    {
        private Vector3 _movemementVelocity;

        public CharacterController CharacterController { get; set; }
        public Transform Model { get; set; }
        public float Speed { get; set; }
        public float VelocityGain { get; set; }
        public float VelocityLoss { get; set; }
        public float ReverseMomentum { get; set; }
        public bool StopHandleInputs { get; set; }

        public PlayerMovementBehaviour()
        {
            _movemementVelocity = Vector3.zero;
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
                if (_movemementVelocity.z > 0)
                    _movemementVelocity.z = Mathf.Max(0, _movemementVelocity.z - VelocityLoss * Time.deltaTime);
                else
                    _movemementVelocity.z = Mathf.Min(0, _movemementVelocity.z + VelocityLoss * Time.deltaTime);

                if (_movemementVelocity.x > 0)
                    _movemementVelocity.x = Mathf.Max(0, _movemementVelocity.x - VelocityLoss * Time.deltaTime);
                else
                    _movemementVelocity.x = Mathf.Min(0, _movemementVelocity.x + VelocityLoss * Time.deltaTime);

            }

            MovementLogic();
        }

        private void MovementLogic()
        {
            //Move
            if (_movemementVelocity.x != 0 || _movemementVelocity.z != 0)
            {
                CharacterController.Move(_movemementVelocity * Time.deltaTime);
                Model.rotation = Quaternion.Slerp(Model.rotation, Quaternion.LookRotation(_movemementVelocity), 0.18f);
            }
        }

        private void HandleInputs()
        {
            //Up & Down
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (_movemementVelocity.z >= 0)
                    _movemementVelocity.z = Mathf.Min(Speed, _movemementVelocity.z + VelocityGain * Time.deltaTime);
                else
                    _movemementVelocity.z = Mathf.Min(0, _movemementVelocity.z + VelocityGain * ReverseMomentum * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (_movemementVelocity.z > 0)
                    _movemementVelocity.z = Mathf.Max(0, _movemementVelocity.z - VelocityGain * ReverseMomentum * Time.deltaTime);
                else
                    _movemementVelocity.z = Mathf.Max(-Speed, _movemementVelocity.z - VelocityGain * Time.deltaTime);
            }
            else
            {
                if (_movemementVelocity.z > 0)
                    _movemementVelocity.z = Mathf.Max(0, _movemementVelocity.z - VelocityLoss * Time.deltaTime);
                else
                    _movemementVelocity.z = Mathf.Min(0, _movemementVelocity.z + VelocityLoss * Time.deltaTime);
            }

            //Left & Right
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (_movemementVelocity.x >= 0)
                    _movemementVelocity.x = Mathf.Min(Speed, _movemementVelocity.x + VelocityGain * Time.deltaTime);
                else
                    _movemementVelocity.x = Mathf.Min(0, _movemementVelocity.x + VelocityGain * ReverseMomentum * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (_movemementVelocity.x > 0)
                    _movemementVelocity.x = Mathf.Max(0, _movemementVelocity.x - VelocityGain * ReverseMomentum * Time.deltaTime);
                else
                    _movemementVelocity.x = Mathf.Max(-Speed, _movemementVelocity.x - VelocityGain * Time.deltaTime);
            }
            else
            {
                if (_movemementVelocity.x > 0)
                    _movemementVelocity.x = Mathf.Max(0, _movemementVelocity.x - VelocityLoss * Time.deltaTime);
                else
                    _movemementVelocity.x = Mathf.Min(0, _movemementVelocity.x + VelocityLoss * Time.deltaTime);
            }
        }
    }
}