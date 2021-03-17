using System;
using Infrastructure;
using Logic;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    [RequireComponent(typeof(Death))]
    [RequireComponent(typeof(Mover))]
    public class Asteroid : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;

        private Death _death;
        private Mover _mover;

        private Vector2 _desiredDirection;

        public Vector2 Direction { get; private set; }

        public void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            _desiredDirection = transform.right;
        }

        private void Awake()
        {
            _death = GetComponent<Death>();
            _mover = GetComponent<Mover>();
        }

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void FixedUpdate()
        {
            Direction = _desiredDirection;
            _mover.Move(Direction);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                if (GetComponent<Health>().Current == 0)
                    _scoreCounter.Increment();
            }

            if (other.TryGetComponent(out Asteroid asteroid))
            {
                _desiredDirection = asteroid.Direction;
            }
        }

        private void OnDeathHappened()
        {
            //_scoreCounter.Increment();
            Destroy(gameObject);
        }
    }
}