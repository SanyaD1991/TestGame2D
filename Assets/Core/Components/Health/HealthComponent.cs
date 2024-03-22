using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent OnChangeHealth;
        [SerializeField] public UnityEvent OnChangeDamage;
        [SerializeField] private UnityEvent OnDie;
        [SerializeField] public HealthChangeEvent OnChange;       

        public void ApplyDamage(int damageValue)
        {
            if (_health <= 0) return;
            _health -= damageValue;
            OnChange?.Invoke(_health);
            OnChangeDamage?.Invoke();
            if (_health <= 0)
            {
                OnDie?.Invoke();
            }

        }

        public void ApplyHealth(int healthValue)
        {
            _health += healthValue;
            OnChange?.Invoke(_health);
            OnChangeHealth?.Invoke();
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public int GetHealth()
        {
            return _health;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {

        }
    }
}
