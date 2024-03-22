using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Components.ColliderBased
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent OnAction;
        [SerializeField] private EnterEvent OnExitAction;


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                OnAction?.Invoke(other.gameObject);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                OnExitAction?.Invoke(other.gameObject);
            }
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {


        }
    }
}
