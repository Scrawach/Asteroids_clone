using Logic;
using Player;
using UI;
using UnityEngine;
using Death = Logic.Death;

namespace Infrastructure
{
    public class GameOver
    {
        private readonly GameFactory _gameFactory;
        private readonly Death _playerDeath;
        
        public GameOver(GameFactory gameFactory, Death playerDeath)
        {
            _gameFactory = gameFactory;
            _playerDeath = playerDeath;
            
            _playerDeath.Happened += OnPlayerDeathDied;
            Time.timeScale = 1f;
        }

        private void OnPlayerDeathDied()
        {
            _playerDeath.Happened -= OnPlayerDeathDied;
            _gameFactory.CreateGameOverWindow();
            Time.timeScale = 0f;
        }
    }
}