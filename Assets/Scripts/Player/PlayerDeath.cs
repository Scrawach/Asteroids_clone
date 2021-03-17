using System;
using Logic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Death))]
    public class PlayerDeath : MonoBehaviour
    {
        private Death _death;

        private void Awake() => 
            _death = GetComponent<Death>();

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened() => 
            Destroy(gameObject);
    }
}