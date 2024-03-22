using UnityEngine;

namespace Core.Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;   

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnInstance(_target.position);
        }

        public void Spawn(Vector3 position)
        {
            SpawnInstance(position);
        }

        public GameObject SpawnInstance(Vector3 position)
        {
            var instance = Instantiate(_prefab, position, Quaternion.identity, _target);
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
