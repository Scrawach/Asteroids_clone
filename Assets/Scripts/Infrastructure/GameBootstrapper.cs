using System;
using Data;
using Infrastructure.AssetManagement;
using Logic;
using Player;
using UnityEngine;
using Death = Logic.Death;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] 
        private Rect _playerPlayingZone;
        
        [SerializeField] 
        private Rect _playingZone;

        [SerializeField] 
        private GameSettings _settings;

        private void Awake() => 
            InitGameWorld();

        private void InitGameWorld()
        {
            var gameFactory = InitGameFactory();

            gameFactory.CreateUIRoot();
            gameFactory.CreateScoreView();
            gameFactory.CreateSpawner(_settings);
            
            var playerDeath = gameFactory
                .CreatePlayerShip(Vector3.zero, _settings.PlayerHealth, _playerPlayingZone)
                .GetComponent<Death>();
            
            var gameOver = new GameOver(gameFactory, playerDeath);
        }

        private GameFactory InitGameFactory()
        {
            var scoreCounter = new ScoreCounter();
            var assetProvider = new AssetProvider();
            var gameFactory = new GameFactory(assetProvider, scoreCounter, _playingZone);
            return gameFactory;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color32(200, 30, 30, 35);
            Gizmos.DrawCube(transform.position.ToVector2() + _playingZone.center, _playingZone.size);
            
            Gizmos.color = new Color32(30, 30, 200, 35);
            Gizmos.DrawCube(transform.position.ToVector2() + _playerPlayingZone.center, _playerPlayingZone.size);
        }
    }
}