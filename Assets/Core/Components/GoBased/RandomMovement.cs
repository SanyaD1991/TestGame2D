
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Components.GoBased
{
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField] private Transform _endPosition;      
        [SerializeField] private float _speed;
        [SerializeField] private EnterEvent OnAction;
        private Vector3 endPoint;
        
        private void Awake()
        {           
            RandomCorner();
        }

        // Update is called once per frame
        private void Update()
        {
            if (transform.position != endPoint)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPoint, _speed);               
            }
            else
            {
                enabled = false;
                OnAction?.Invoke();
            }
        }

        private void RandomCorner()
        {
           transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, UnityEngine.Random.Range(0f, 360f));
           endPoint = _endPosition.position;
           enabled = true;
        }


        [Serializable]
        public class EnterEvent : UnityEvent
        {


        }
    }
}
