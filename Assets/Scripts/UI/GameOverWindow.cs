using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField]
        private Button _restartButton;

        [SerializeField] 
        private Button _quitButton;

        private ScoreView _scoreView;

        public void Construct(ScoreCounter counter) =>
            _scoreView.Construct(counter);

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartClicked);
            _quitButton.onClick.AddListener(OnQuitClicked);
        }
        
        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartClicked);
            _quitButton.onClick.RemoveListener(OnQuitClicked);
        }

        private void OnQuitClicked() => 
            Application.Quit();

        private void OnRestartClicked() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
