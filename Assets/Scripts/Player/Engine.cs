using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;
        
        [SerializeField]
        private float _accelerationModifier = 1;
        
        private Rigidbody2D _rigidbody;
        
        private Vector2 _velocity;
        private Rect _workingBounds;

        public void Construct(Rect workingZone) => 
            _workingBounds = workingZone;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        public void Move(Vector2 direction)
        {
            var currentPosition = transform.position.ToVector2();
            var desiredVelocity = direction * _speed;
            var acceleration = (desiredVelocity - _velocity) * _accelerationModifier;
            _velocity += acceleration * Time.fixedDeltaTime;

            var movement = _velocity * Time.fixedDeltaTime;
            var nextPosition = currentPosition + movement;

            var clampedPosition = nextPosition.Clamp(_workingBounds.min, _workingBounds.max);
            _rigidbody.MovePosition(clampedPosition);
        }
    }
}