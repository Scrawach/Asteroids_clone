using System;
using Infrastructure;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _score;
        
        private ScoreCounter _scoreCounter;
        
        public void Construct(ScoreCounter scoreCounter)
        {
            if (_scoreCounter != null)
                CleanUp();
            
            _scoreCounter = scoreCounter;
            _scoreCounter.Changed += OnScoreChanged;
            _score.text = _scoreCounter.Value.ToString();
        }

        private void OnDestroy() => 
            CleanUp();

        private void CleanUp() => 
            _scoreCounter.Changed -= OnScoreChanged;

        private void OnScoreChanged(int value) => 
            _score.text = value.ToString();
    }
}