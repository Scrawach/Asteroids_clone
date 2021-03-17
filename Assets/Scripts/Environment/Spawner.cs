using System;
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

        [SerializeField] 
        private Rect _workingZone;

        [SerializeField] 
        private float _spawnCooldown;
        
        private float _elapsedTime;
        
        private GameFactory _gameFactory;

        public void Construct(GameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void Update()
        {
            if (CanSpawn())
            {
                SpawnAsteroidInBorder();
                ResetCooldown();
            }
            else
            {
                UpdateCooldown();
            }
        }

        private void UpdateCooldown() => 
            _elapsedTime += Time.deltaTime;

        private void ResetCooldown() => 
            _elapsedTime = 0f;

        private bool CanSpawn() => 
            _spawnCooldown <= _elapsedTime;

        private void SpawnAsteroidInBorder()
        {
            var position = Vector2.zero;
            var rotation = Quaternion.identity;

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

            _gameFactory.CreateAsteroid(position, rotation, 1);
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