using System;
using Logic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Mover))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] 
        private int _damage;

        private Mover _mover;

        private void Awake() => 
            _mover = GetComponent<Mover>();

        private void FixedUpdate() => 
            _mover.Move(transform.right);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health damageable))
                damageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}