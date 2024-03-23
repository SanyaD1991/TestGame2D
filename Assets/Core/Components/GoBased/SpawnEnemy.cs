using Core.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Components.GoBased
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameSession _session;
        [SerializeField] private Transform _parent;       
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _quantity = 1;


        private void Start()
        {
            StartCoroutine(Spawn());
        }


        public GameObject SpawnInstance()
        {
            var instance = Instantiate(_prefab, transform.position , Quaternion.identity);
            instance.GetComponent<AgenMovement>().SetTarget(_session.PlayerTransform);
            instance.transform.parent = _parent;
            var scale = _parent.lossyScale;
            instance.transform.localScale = scale;
            instance.SetActive(true);
            return instance;
        }
        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(1);
            SpawnInstance();
            _quantity--;
            if (_quantity>0)
            {
                StartCoroutine(Spawn());
            }
        }
    }
}
