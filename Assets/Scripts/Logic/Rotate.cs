using System;
using UnityEngine;

namespace Logic
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] 
        private float _speedInDegrees;

        private void Update() => 
            transform.Rotate(0, 0, _speedInDegrees * Time.deltaTime);
    }
}