using Core.Components.Health;
using Core.Model;
using UnityEngine;
namespace Core.Creatures.Player
{
    public class Player : Creature
    {
        private GameSession _session;
        private HealthComponent _Health;
        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _Health = GetComponent<HealthComponent>();
            _session.SetPlayer(this);
            _Health.SetHealth(_session.HP);
        }

        public void TakeDamage()
        {
            _session.OnChanged?.Invoke(_Health.GetHealth());
        }

        public void AddOre(GameObject target)
        {
            _session.SetOre(1);
            Destroy(target);
        }

    }
}
