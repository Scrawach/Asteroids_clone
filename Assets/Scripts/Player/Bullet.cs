using System;
using Logic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] 
        private int _damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health damageable))
                damageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}