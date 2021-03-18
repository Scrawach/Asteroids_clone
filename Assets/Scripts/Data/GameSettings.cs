using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Asteroids", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public int PlayerHealth;
        public int AsteroidRecycle;
        public int AlienHealth;

        public float AsteroidSpawnCooldown;
        public float AlienSpawnCooldown;
    }
}