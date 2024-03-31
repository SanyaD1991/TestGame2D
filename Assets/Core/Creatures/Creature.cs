using UnityEngine;

namespace Core.Creatures
{
    public class Creature : MonoBehaviour
    {

        [SerializeField] private float _speed;  
        [Range(0.0f, 0.3f)]
        [SerializeField] private float _rotationSmoothTime = 0.12f;
        [SerializeField] protected Joystick _joystick;
        protected Vector2 _direction;
        protected Rigidbody2D _rigidbody;

        private float _targetRotation;
        private float _rotationVelocity;


        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();         
        }

        public void SetVectorDirection(Vector2 vectorDirection)
        {
            _direction = vectorDirection;
        }

        private void FixedUpdate()
        {
            if (_joystick != null) SetVectorDirection(_joystick.Direction);
            Move();
        }

        private void Move()
        {
            if (_direction.magnitude > 0) 
            {
                _targetRotation = Mathf.Atan2(_direction.x * -1, _direction.y) * Mathf.Rad2Deg;
                float rotation = Mathf.LerpAngle(_rigidbody.rotation, _targetRotation, _rotationSmoothTime);                
                _rigidbody.velocity = _direction * _speed; 
                _rigidbody.rotation= rotation;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                
            }
        }
    }
}
