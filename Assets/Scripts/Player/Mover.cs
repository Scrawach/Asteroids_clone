using System;
using UnityEngine;

namespace Player
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
            var current = transform.position.ToVector2();
            var step = _speed * Time.fixedDeltaTime;
            var movement = direction * step;
            
            _rigidbody.MovePosition(current + movement);
        }
    }
}