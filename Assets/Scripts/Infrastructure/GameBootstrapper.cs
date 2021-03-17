using System;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] 
        private Rect _playerPlayingZone;
        
        [SerializeField] 
        private Rect _playingZone;
        
        private void Awake()
        {
            var scoreCounter = new ScoreCounter();
            var gameFactory = new GameFactory(scoreCounter, _playingZone);

            gameFactory.CreateHUD();
            gameFactory.CreatePlayerShip(Vector3.zero, _playerPlayingZone);
            gameFactory.CreateSpawner();
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