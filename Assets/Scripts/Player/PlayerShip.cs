using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Weapon))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;
        
        [SerializeField]
        private float _accelerationModifier = 1;

        [SerializeField] 
        private Weapon _defaultWeapon;
        
        [SerializeField] 
        private Weapon _altWeapon;
        
        private Rect _workingBounds;

        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody;
        private Vector2 _velocity;

        public void Construct(Rect workingZone) => 
            _workingBounds = workingZone;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }
        
        private void FixedUpdate()
        {
            Move(_playerInput.Direction);
            
            if (_playerInput.Fired)
                _defaultWeapon.TryFire();
            
            if (_playerInput.AltFired)
                _altWeapon.TryFire();
        }

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