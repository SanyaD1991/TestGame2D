using Core.Components.GoBased;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Components.LevelManagement
{    
    public class LevelGeneration : MonoBehaviour
    {
        [SerializeField] private float _width;
        [SerializeField] private float _height;
        [Range(0f, 1f)]
        [SerializeField] private float _probability = 0.5f;
        [Range(0f, 1f)]
        [SerializeField] private float _density = 0.5f;
        [SerializeField] private SpawnComponent _wallDefault;
        [SerializeField] private SpawnComponent _wallOre;
        [SerializeField] private SpawnComponent _player;       
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
                    if (Random.value > _density)
                    {
                        //Создание блоков
                        Vector2 position = CalculatePosition(x, y);
                        if (Random.value > _probability)
                        {
                            _wallDefault.Spawn(position);
                        }
                        else
                        {
                            _wallOre.Spawn(position);
                        }
                      
                    }
                    else if(!playerSpawned)
                    {
                        //Создание игрока
                        Vector2 position = CalculatePosition(_height / 2, _width / 2);
                        _player.Spawn(position);
                         playerSpawned = true;
                    }
                }
            }
        }

        private Vector2 CalculatePosition(float x, float y)
        {
            return new Vector2(x - _width / 2f, y - _height / 2f);
        }
    }
}
