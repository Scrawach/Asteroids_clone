using System;
using Logic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Death))]
    public class Alien : MonoBehaviour
    {
        private Transform _target;
        private Mover _mover;
        private Death _death;
        
        public void Construct(Transform target) => 
            _target = target;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _death = GetComponent<Death>();
        }

        private void OnEnable() => 
            _death.Happened += OnDied;

        private void OnDisable() => 
            _death.Happened -= OnDied;

        private void OnDied() => 
            Destroy(gameObject);

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            var direction = _target.position - transform.position;
            var normalizedDirection = direction.normalized;
            _mover.Move(normalizedDirection);
        }
    }
}