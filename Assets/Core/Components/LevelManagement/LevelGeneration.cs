using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Components.LevelManagement
{    
    public class LevelGeneration : MonoBehaviour
    {
        [SerializeField] private float _width;
        [SerializeField] private float _height;
        [SerializeField] private GameObject _wall;
        [SerializeField] private GameObject _player;
        private bool playerSpawned = false;

        private void Start()
        {
            GenerateLevel();
        }

        //Генерация уровня
        private void GenerateLevel()
        {
            for (int x = 0; x <= _width; x++)
            {
                for (int y=0; y<=_height; y++)
                {
                    if (Random.value >0.5f)
                    {
                        //Создание блоков
                        Vector2 pos = CalculatePosition(x, y);
                        Instantiate(_wall, pos, Quaternion.identity, transform);
                    }
                    else if(!playerSpawned)
                    {
                        //Создание игрока
                        Vector2 pos = CalculatePosition(x, y);
                        Instantiate(_player, pos, Quaternion.identity);
                        playerSpawned = true;
                    }
                }
            }
        }

        private Vector2 CalculatePosition(int x, int y)
        {
            return new Vector2(x - _width / 2f, y - _height / 2f);
        }
    }
}
