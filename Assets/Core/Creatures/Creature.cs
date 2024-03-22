using UnityEngine;

namespace Core.Creatures
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float _speed;
        protected Vector2 _direction;
        protected Rigidbody2D _rigidbody;

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
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = _direction * _speed;
        }
    }
}
