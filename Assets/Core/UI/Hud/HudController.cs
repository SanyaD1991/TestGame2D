using Core.Model;
using Core.UI.Widgets;
using UnityEngine;

namespace Core.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ProgressBarWidet _healtBar;
       [SerializeField] private GameSession _gameSession;
        private int _maxHealth;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            _maxHealth= _gameSession.HP;
            _gameSession.OnChanged += OnHealthChanget;
        }

        private void OnHealthChanget(int value)
        {
            var healtvalue = (float)value / _maxHealth;
            _healtBar.SetProgress(healtvalue);
        }

        private void OnDestroy()
        {
            _gameSession.OnChanged -= OnHealthChanget;
        }               
    }
}
