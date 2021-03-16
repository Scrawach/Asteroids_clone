using System;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Death))]
    public class DeathEffect : MonoBehaviour
    {
        [SerializeField] 
        private ParticleSystem _effect;

        private Death _death;
        
        private void Awake() => 
            _death = GetComponent<Death>();

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened()
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
        }
    }
}