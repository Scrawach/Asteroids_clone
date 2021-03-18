using System;
using Infrastructure;
using Player;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Death))]
    public class Score : MonoBehaviour
    {
        [SerializeField] 
        private int _value;

        private ScoreCounter _counter;

        private Health _health;
        private bool _playerLastHit;
        
        public void Construct(ScoreCounter counter) => 
            _counter = counter;

        private void Awake() => 
            _health = GetComponent<Health>();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _playerLastHit = other.TryGetComponent(out Bullet bullet);
            
            if (_playerLastHit && _health.Current <= 0)
                _counter.Increment(_value);
        }
    }
}