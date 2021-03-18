using System;
using Data;
using Infrastructure;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] 
        private Rect _spawnZone;

        private float _asteroidElapsedTime;
        private float _alienElapsedTime;
        
        private GameFactory _gameFactory;
        private GameSettings _settings;

        public void Construct(GameFactory gameFactory, GameSettings settings)
        {
            _gameFactory = gameFactory;
            _settings = settings;
        }

        private void Update()
        {
            TrySpawn(_asteroidElapsedTime, _settings.AsteroidRecycle, SpawnAsteroidInBorder);
            TrySpawn(_alienElapsedTime, _settings.AlienSpawnCooldown, SpawnAlien);

            _alienElapsedTime += Time.deltaTime;
            _asteroidElapsedTime += Time.deltaTime;
        }
        
        private void TrySpawn(float elapsedTime, float targetTime, Action spawnFunc)
        {
            if (elapsedTime > targetTime)
                spawnFunc?.Invoke();
        }
        
        private void SpawnAlien()
        {
            var rotation = Quaternion.identity;
            var position = GetCoords(ref rotation);

            _gameFactory.CreateAlien(position, _settings.AlienHealth);
            _alienElapsedTime = 0f;
        }

        private void SpawnAsteroidInBorder()
        {
            var rotation = Quaternion.identity;
            var position = GetCoords(ref rotation);

            _gameFactory.CreateAsteroid(position, rotation, _settings.AsteroidRecycle);
            _asteroidElapsedTime = 0f;
        }

        private Vector2 GetCoords(ref Quaternion rotation)
        {
            var position = Vector2.zero;
            
            switch (Random.Range(0, 4))
            {
                case 0:
                    position = new Vector2(_spawnZone.xMin, _spawnZone.yMin);
                    rotation = Quaternion.AngleAxis(Random.Range(0, 90), Vector3.forward);
                    break;
                case 1:
                    position = new Vector2(_spawnZone.xMax, _spawnZone.yMin);
                    rotation = Quaternion.AngleAxis(Random.Range(90, 180), Vector3.forward);
                    break;
                case 2:
                    position = new Vector2(_spawnZone.xMax, _spawnZone.yMax);
                    rotation = Quaternion.AngleAxis(Random.Range(180, 270), Vector3.forward);
                    break;
                case 3:
                    position = new Vector2(_spawnZone.xMin, _spawnZone.yMax);
                    rotation = Quaternion.AngleAxis(Random.Range(270, 360), Vector3.forward);
                    break;
            }

            return position;
        }

        private Vector2 GetRandomPosition()
        {
            return new Vector2(Random.Range(_spawnZone.xMin, _spawnZone.xMax), 
                Random.Range(_spawnZone.yMin, _spawnZone.yMax));
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color32(30, 200, 30, 35);
            Gizmos.DrawCube(transform.position.ToVector2() + _spawnZone.center, _spawnZone.size);
        }
    }
}