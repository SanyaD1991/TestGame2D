using Core.Components.GoBased;
using Core.Creatures.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Creatures
{
    public class Projectile : BaseProjectile
    {   protected override void Start()
        {
            base.Start();         
        }

        public void AddForce(Transform aim)
        {
            var force = aim.up * _speed;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}