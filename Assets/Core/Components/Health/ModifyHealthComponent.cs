using UnityEngine;

namespace Core.Components.Health
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int LifeValue;
        [SerializeField] private bool isDomage;

        private bool isApplay;
        private int CriticalDamage;

        public void SetDelta(int delta)
        {
            LifeValue = delta;
        }

        public void ModifyHealth(GameObject target)
        {
            var _healthComponent = target.GetComponent<HealthComponent>();
            if (_healthComponent != null)
            {
                if (isDomage)
                {

                    int random = Random.Range(0, 100);               
                    int damage = random < CriticalDamage ? 100 : LifeValue;                  
                    _healthComponent.ApplyDamage(damage);

                }
                else
                {
                    if (!isApplay)
                    {
                        _healthComponent.ApplyHealth(LifeValue);
                        isApplay = true;
                    }
                }

            }
        }

        public void SetLifeValue(int value)
        {
            LifeValue = value;
        }

        public void SetCriticalDamage(int value)
        {
            print("SetCriticalDamage=" + value);
            CriticalDamage = value;
        }
    }
}
