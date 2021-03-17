using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Engine))]
    [RequireComponent(typeof(Weapon))]
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const string FireButton = "Fire1";

        private Engine _ship;
        private Weapon _weapon;
        
        private Vector2 _desiredDirection;

        private void Awake()
        {
            _ship = GetComponent<Engine>();
            _weapon = GetComponent<Weapon>();
        }

        private void Update()
        {
            _desiredDirection = ReadInput().normalized;
            
            if (Input.GetButton(FireButton))
                _weapon.TryFire();
        }

        private void FixedUpdate() => 
            _ship.Move(_desiredDirection);

        private Vector2 ReadInput() =>
            new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));
    }
}
