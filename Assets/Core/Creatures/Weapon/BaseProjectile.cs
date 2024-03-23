
using UnityEngine;

namespace Core.Creatures.Weapons
{
    public class BaseProjectile : MonoBehaviour
    {
        [SerializeField] protected float _speed;      

        protected Rigidbody2D _rigidbody;      

        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
