using Data;
using Enemy;
using Environment;
using Infrastructure.AssetManagement;
using Logic;
using Player;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameFactory
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly AssetProvider _assetProvider;
        private readonly Rect _playingZone;

        private Transform _uiRoot;
        private PlayerShip _playerShip;

        public GameFactory(AssetProvider assetProvider, ScoreCounter scoreCounter, Rect playingZone)
        {
            _assetProvider = assetProvider;
            _scoreCounter = scoreCounter;
            _playingZone = playingZone;
        }

        public Spawner CreateSpawner(GameSettings settings)
        {
            var spawner = _assetProvider.Initialize(AssetPath.Spawner).GetComponent<Spawner>();
            spawner.Construct(this, settings);
            return spawner;
        }

        public Alien CreateAlien(Vector3 position, int healthValue)
        {
            var alien = _assetProvider.Initialize(AssetPath.AlienShip, position).GetComponent<Alien>();
            alien.Construct(_playerShip.transform);
            
            if (alien.TryGetComponent(out Health health))
                health.Construct(healthValue,healthValue);
            
            if (alien.TryGetComponent(out Score score))
                score.Construct(_scoreCounter);
            
            return alien;
        }
        
        public Asteroid CreateAsteroid(Vector3 position, Quaternion rotation, int recycle, float size = 1)
        {
            var asteroid = _assetProvider.Initialize(AssetPath.Asteroid, at: position, rotation).GetComponent<Asteroid>();
            asteroid.transform.localScale *= size;
            
            if (asteroid.TryGetComponent(out Score score))
                score.Construct(_scoreCounter);
            
            if (asteroid.TryGetComponent(out AsteroidRecycleSpawn recycleSpawn))
                recycleSpawn.Construct(this, recycle);

            if (asteroid.TryGetComponent(out Health health))
                health.Construct(recycle + 1, recycle + 1);
            
            if (asteroid.TryGetComponent(out InsidePlayingZoneChecker checker))
                checker.Construct(_playingZone);
            
            return asteroid;
        }

        public PlayerShip CreatePlayerShip(Vector3 position, int health, Rect workingZone)
        {
            _playerShip = _assetProvider.Initialize(AssetPath.PlayerShip, at: position).GetComponent<PlayerShip>();
            _playerShip.Construct(workingZone);
            _playerShip.GetComponent<Health>().Construct(health, health);
            return _playerShip;
        }
        
        public Transform CreateUIRoot()
        {
            _uiRoot = _assetProvider.Initialize(AssetPath.UIRoot).transform;
            return _uiRoot;
        }
        
        public ScoreView CreateScoreView()
        {
            var scoreView = _assetProvider.Initialize(AssetPath.ScoreViewHud, _uiRoot).GetComponent<ScoreView>();
            scoreView.Construct(_scoreCounter);
            return scoreView;
        }
        
        public GameOverWindow CreateGameOverWindow()
        {
            var scoreView = _assetProvider.Initialize(AssetPath.GameOverWindow, _uiRoot).GetComponent<GameOverWindow>();
            scoreView.Construct(_scoreCounter);
            return scoreView;
        }
    }
}