using Core.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;
namespace Core.Components.ColliderBased
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private bool _isCheckLayer;
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent OnAction;
        [SerializeField] private EnterEvent OnExitAction;

        [SerializeField] private bool _isKill;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isKill) Destroy(other.gameObject);
            if (_isCheckLayer)
            {
                if (!other.gameObject.IsInLayer(_layer)) return;
            }
            else
            {
                if (string.IsNullOrEmpty(_tag)) return;
                if (!other.gameObject.CompareTag(_tag)) return;
            }
            OnAction?.Invoke(other.gameObject);

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (string.IsNullOrEmpty(_tag)) return;
            if (!other.gameObject.CompareTag(_tag)) return;
            OnExitAction?.Invoke(other.gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {


        }
    }
}
