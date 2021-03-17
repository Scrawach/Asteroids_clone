using Environment;
using Logic;
using Player;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameFactory
    {
        private readonly ScoreCounter _scoreCounter;
        
        private Asteroid _asteroidPrefab;
        private Engine _shipPrefab;
        private ScoreView _hudPrefab;
        private Spawner _spawnerPrefab;
        
        private Rect _playingZone;

        public GameFactory(ScoreCounter scoreCounter, Rect playingZone)
        {
            _scoreCounter = scoreCounter;
            _playingZone = playingZone;
            InitializePrefabs();
        }
        
        private void InitializePrefabs()
        {
            _asteroidPrefab = Resources.Load<Asteroid>(AssetPath.Asteroid);
            _shipPrefab = Resources.Load<Engine>(AssetPath.PlayerShip);
            _hudPrefab = Resources.Load<ScoreView>(AssetPath.HUD);
            _spawnerPrefab = Resources.Load<Spawner>(AssetPath.Spawner);
        }

        public Spawner CreateSpawner()
        {
            var spawner = Object.Instantiate(_spawnerPrefab);
            spawner.Construct(this);
            return spawner;
        }

        public ScoreView CreateHUD()
        {
            var view = Object.Instantiate(_hudPrefab);
            view.Construct(_scoreCounter);
            return view;
        }
        
        public Asteroid CreateAsteroid(Vector3 position, Quaternion rotation, int recycle, float size = 1)
        {
            var asteroid = Object.Instantiate(_asteroidPrefab, position, rotation);
            asteroid.Construct(_scoreCounter);
            asteroid.transform.localScale *= size;
            
            if (asteroid.TryGetComponent(out AsteroidRecycleSpawn recycleSpawn))
                recycleSpawn.Construct(this, recycle);

            if (asteroid.TryGetComponent(out Health health))
                health.Construct(recycle + 1, recycle + 1);
            
            if (asteroid.TryGetComponent(out InsidePlayingZoneChecker checker))
                checker.Construct(_playingZone);
            
            return asteroid;
        }

        public Engine CreatePlayerShip(Vector3 position, Rect workingZone)
        {
            var ship = Object.Instantiate(_shipPrefab, position, Quaternion.identity);
            ship.Construct(workingZone);
            return ship;
        }
    }
}