using System;
using Logic;
using UnityEngine;

namespace Environment
{
    public class DamageWhenTrigger : MonoBehaviour
    {
        [SerializeField] 
        private int _value;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
                health.TakeDamage(_value);
        }
    }
}