using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponCooldownView : MonoBehaviour
    {
        [SerializeField] 
        private Weapon _weapon;

        [SerializeField] 
        private Image _cooldownBar;

        private void Awake() => 
            _cooldownBar.rectTransform.localScale = Vector3.one;

        private void OnEnable() => 
            _weapon.ElapsedTimeUpdated += OnElapsedTimeUpdated;

        private void OnDisable() => 
            _weapon.ElapsedTimeUpdated -= OnElapsedTimeUpdated;

        private void OnElapsedTimeUpdated(float value) => 
            _cooldownBar.rectTransform.localScale = Vector3.one * value;
    }
}