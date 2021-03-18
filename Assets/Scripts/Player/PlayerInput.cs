using System;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private const string FireButton = "Fire1";
        private const string AltFireButton = "Fire2";
        
        public Vector2 Direction { get; private set; }
        public bool Fired { get; private set; }
        public bool AltFired { get; private set; }
        
        private void Update()
        {
            Direction = ReadInput().normalized;
            Fired = Input.GetButton(FireButton);
            AltFired = Input.GetButton(AltFireButton);
        }
        
        private Vector2 ReadInput() =>
            new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));
    }
}
