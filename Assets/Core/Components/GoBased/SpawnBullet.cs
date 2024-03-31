using Core.Components.ColliderBased;
using Core.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private Transform _aim;    
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;   


    public void Spawn(Vector2 look)
    {
        GameObject bullet = Instantiate(_prefab, _aim.position, _aim.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();        
        rb.AddForce(look * _speed, ForceMode2D.Impulse); 
    }  
}
