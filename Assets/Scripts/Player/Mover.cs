using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;
        
        [SerializeField]
        private float _accelerationModifier = 1;
        
        private Rigidbody2D _rigidbody;

        private Vector2 _currentMovement;
        private Vector2 _targetMovement;

        private Vector2 _velocity;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        public void Move(Vector2 direction)
        {
            var currentPosition = transform.position.ToVector2();
            var desiredVelocity = direction * _speed;
            var acceleration = (desiredVelocity - _velocity) * _accelerationModifier;
            _velocity += acceleration * Time.fixedDeltaTime;

            var movement = _velocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(currentPosition + movement);
        }
    }
}