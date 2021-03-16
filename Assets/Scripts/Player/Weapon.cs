using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] 
        private Transform _shotPoint;
        
        [SerializeField] 
        private Bullet _bulletPrefab;
        
        [SerializeField] 
        private float _cooldownTime;

        private float _elapsedTime;

        private void Update()
        {
            if (CanShot())
                return;
            
            UpdateCooldown();
        }

        public void TryFire()
        {
            if (CanShot())
                Fire();
        }

        private void Fire()
        {
            CreateBullet();
            ResetCooldown();
        }

        private void CreateBullet() =>
            Instantiate(_bulletPrefab, _shotPoint.position, transform.rotation);

        private void UpdateCooldown() =>
            _elapsedTime += Time.deltaTime;

        private void ResetCooldown() =>
            _elapsedTime = 0f;

        private bool CanShot() =>
            _elapsedTime >= _cooldownTime;
    }
}
