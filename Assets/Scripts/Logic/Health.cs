using System;
using UnityEngine;

namespace Logic
{
    public class Health : MonoBehaviour
    {
        public int Current { get; private set; }
        public int Max { get; private set; }

        public bool IsDead => Current <= 0;
        public event Action<int> Changed;

        public void Construct(int current, int max)
        {
            Current = current;
            Max = max;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;
            Changed?.Invoke(Current);
        }
    }
}