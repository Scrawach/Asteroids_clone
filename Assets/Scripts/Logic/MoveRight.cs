using System;
using Player;
using UnityEngine;

namespace Logic
{
    public class MoveRight : Mover
    {
        private void Update() => 
            Move(transform.right);
    }
}
