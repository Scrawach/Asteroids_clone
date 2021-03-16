using System;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class HitEffect : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _effect;

        private void OnTriggerEnter2D(Collider2D other) => 
            Instantiate(_effect, transform.position, Quaternion.identity);
    }
}