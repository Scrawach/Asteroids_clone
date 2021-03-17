using System;
using Player;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;
        
        private Rigidbody2D _rigidbody;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();
        
        public void Move(Vector2 direction)
        {
            var currentPosition = transform.position.ToVector2();
            var desiredVelocity = direction * _speed;
            var movement = desiredVelocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(currentPosition + movement);
        }
    }
}
