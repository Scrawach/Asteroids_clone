using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Mover))]
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const string FireButton = "Fire1";

        private Mover _ship;
        
        private Vector2 _desiredDirection;

        private void Awake()
        {
            _ship = GetComponent<Mover>();
        }

        private void Update()
        {
            _desiredDirection = ReadInput().normalized;
        }

        private void FixedUpdate() => 
            _ship.Move(_desiredDirection);

        private Vector2 ReadInput() =>
            new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));
    }
}
