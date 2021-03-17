using System;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Health))]
    public class Death : MonoBehaviour
    {
        private Health _objectHealth;

        public event Action Happened;

        private void Awake() => 
            _objectHealth = GetComponent<Health>();

        private void OnEnable() => 
            _objectHealth.Changed += OnHealthChanged;

        private void OnDisable() => 
            _objectHealth.Changed -= OnHealthChanged;

        private void OnHealthChanged(int value)
        {
            if (value == 0)
                Happened?.Invoke();
        }
    }
}