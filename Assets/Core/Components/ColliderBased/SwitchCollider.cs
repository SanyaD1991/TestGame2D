using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Components.ColliderBased
{
    public class SwitchCollider : MonoBehaviour
    {
        [SerializeField] private Collider2D collider;


        public void Reset(float time)
        {
            StartCoroutine(OffOn(time));
        }

        private IEnumerator OffOn(float time)
        {
            collider.enabled = false;
            yield return new WaitForSeconds(time);
            collider.enabled = true;
        }
    }
}
