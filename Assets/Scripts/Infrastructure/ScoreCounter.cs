using System;

namespace Infrastructure
{
    public class ScoreCounter
    {
        public int Value { get; private set; }

        public event Action<int> Changed;
        
        public void Increment(int value = 1)
        {
            Value += value;
            Changed?.Invoke(Value);
        }
    }
}