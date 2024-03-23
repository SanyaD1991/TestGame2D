using UnityEngine;

namespace Core.Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private bool _isTargetParent=true;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _quantity = 1;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            for (int i = 0; i < _quantity; i++)
            {
                SpawnInstance(_target.position);
            }
        }

        public GameObject Spawn(Vector3 position)
        {
            for (int i = 0; i < _quantity; i++)
            {
               return SpawnInstance(position);
            }
            return null;
        }

        public GameObject SpawnInstance(Vector3 position)
        {
            var instance = Instantiate(_prefab, position, Quaternion.identity);            
            if (_isTargetParent) 
            {
                instance.transform.parent=_target;
            }
          
            var scale = _target.lossyScale;
            instance.transform.localScale = scale;
            instance.SetActive(true);
            return instance;
        }

        internal void SetPrefab(GameObject prefab)
        {
            _prefab = prefab;
        }
    }
}
