using System;
using Infrastructure;
using Logic;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Death = Logic.Death;
using Random = UnityEngine.Random;

namespace Environment
{
    [RequireComponent(typeof(Death))]
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Score))]
    [RequireComponent(typeof(AsteroidRecycleSpawn))]
    public class Asteroid : MonoBehaviour
    {
        private Health _health;
        private Death _death;
        private Mover _mover;
        
        private AsteroidRecycleSpawn _recycleSpawn;

        private Vector2 _desiredDirection;
        private bool _isLaser;

        public Vector2 Direction { get; private set; }
        
        private void Awake()
        {
            _death = GetComponent<Death>();
            _mover = GetComponent<Mover>();
            _health = GetComponent<Health>();
            _recycleSpawn = GetComponent<AsteroidRecycleSpawn>();
            _desiredDirection = transform.right;
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
            if (other.TryGetComponent(out Asteroid asteroid))
                _desiredDirection = asteroid.Direction;
            
            if (!other.TryGetComponent(out Laser laser) && _health.IsDead)
                _recycleSpawn.Spawn();
        }

        private void OnDeathHappened() => 
            Destroy(gameObject);
    }
}