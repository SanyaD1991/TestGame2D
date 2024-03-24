using Core.Components.ColliderBased;
using Core.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private float _reload;
    [SerializeField] private Transform _aim;    
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;   
    [SerializeField] private LayerMask layerWall;
    [SerializeField] private SwitchCollider _switch;
    private bool _block;
    private List<Vector3> _listEnemy = new List<Vector3>();

    private IEnumerator Spawn(Vector2 look)
    {
        GameObject bullet = Instantiate(_prefab, _aim.position, _aim.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();        
        rb.AddForce(look * _speed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_reload);
        _block = false;
    }    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (string.IsNullOrEmpty(_tag)) return;
        if (!other.gameObject.CompareTag(_tag)) return;
        _listEnemy.Add(other.transform.position);
        LookAt();

    }
   
    private void LookAt()
    {
        _switch.Off();
        for (int i=0; i< _listEnemy.Count; i++)
        {
           Vector3 look = transform.position-_listEnemy[i];
          
           float angle = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg-90;
            transform.eulerAngles = new Vector3(0,0,angle);          
            RaycastHit2D hit = Physics2D.Raycast(transform.position, look*-1, Vector3.Distance(transform.position, _listEnemy[i]), layerWall);
            Debug.DrawRay(transform.position, look * -1f, Color.red);
          
            if (hit.transform==null && !_block)
            {
                _block = true;
                StartCoroutine(Spawn(look * -1));               
                break;
            }
        }       
        _listEnemy.Clear();
        _switch.Reset(0.5f);
    }



}
