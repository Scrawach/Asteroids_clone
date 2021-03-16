using System;
using UnityEngine;

namespace Player
{
    public class RotateToMouse : MonoBehaviour
    {
        [SerializeField] 
        private float _rotateSpeed;

        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            var worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            var direction = worldPoint - transform.position;
            
            Rotate(to: direction);
        }

        private void Rotate(Vector2 to)
        {
            var angle = Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg;
            var targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime);
        }
    }
}