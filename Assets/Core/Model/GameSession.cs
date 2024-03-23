using Core.Creatures.Player;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Core.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _ore;
        private Player _player;
        public Action<int> OnChanged;

        public Transform PlayerTransform => _player.transform;
        public int HP => _hp;

        private void Start()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
           // SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
            OnChanged += Checked;
        }
        public void SetPlayer(Player player)
        {
            _player = player;
        }

        private void Checked(int value)
        {
            _hp = value;
        }
        private void OnDestroy()
        {
            OnChanged -= Checked;
        }

        public void SetOre(int value)
        {
            _ore += value;
        }
    }
}
