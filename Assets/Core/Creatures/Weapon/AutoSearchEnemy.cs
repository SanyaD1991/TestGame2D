using Core.Components.ColliderBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Creatures.Weapons
{
    public class AutoSearch : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private float _reload;      
        [SerializeField] private LayerMask layerObstacles;
        [SerializeField] private SwitchCollider _switch;
        [SerializeField] private EnterEvent OnAction;

        private bool _block;
        private List<Vector3> _listEnemy = new List<Vector3>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.IsNullOrEmpty(_tag)) return;
            if (!other.gameObject.CompareTag(_tag)) return;
            _listEnemy.Add(other.transform.position);
            FindVisibleTarget();
        }

        private Vector3 LookAt(Vector3 targetPosition)
        {
            Vector3 look = transform.position - targetPosition;
            float angle = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg - 90;
            return new Vector3(0, 0, angle);
        }

        private bool SearchObstacles(Vector3 targetPosition)
        {
            Vector3 look = transform.position - targetPosition;
            transform.eulerAngles = LookAt(targetPosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, look * -1, Vector3.Distance(transform.position, targetPosition), layerObstacles);
            Debug.DrawRay(transform.position, look * -1f, Color.red);
            return hit.transform == null;
        }

        private void FindVisibleTarget()
        {
            _switch.Off();
            for (int i = 0; i < _listEnemy.Count; i++)
            {
                Vector3 look = transform.position - _listEnemy[i];
                float angle = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg - 90;

                bool isHit = SearchObstacles(_listEnemy[i]);
                if (isHit && !_block)
                {
                    _block = true;
                    StartCoroutine(Invoke(look * -1));                    
                    break;
                }
            }
            _listEnemy.Clear();
            _switch.Reset(0.5f);
        }
        private IEnumerator Invoke(Vector2 look)
        {
            OnAction?.Invoke(look);
            yield return new WaitForSeconds(_reload);
            _block = false;
        }

        [Serializable]
        public class EnterEvent : UnityEvent<Vector2>
        {


        }
    }   
}
