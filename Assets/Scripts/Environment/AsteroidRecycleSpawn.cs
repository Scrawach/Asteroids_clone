using Infrastructure;
using Logic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    [RequireComponent(typeof(Asteroid))]
    public class AsteroidRecycleSpawn : MonoBehaviour
    {
        private const float InsideCircleModifier = .15f;
        private const int RecycleSpawnInDegrees = 45;
        private const float RecycleSizeModifier = .5f;
        
        private GameFactory _gameFactory;
        private int _recycle;

        public void Construct(GameFactory gameFactory, int recycle)
        {
            _gameFactory = gameFactory;
            _recycle = recycle;
        }
        
        public void Spawn()
        {
            if (NeedRecycleSpawn())
                RecycleSpawn();
        }
        
        private bool NeedRecycleSpawn() =>
            _recycle > 0;
        
        private void RecycleSpawn()
        {
            var radius = Vector2.one * InsideCircleModifier;
            CreateSmallAsteroid(radius, RecycleSpawnInDegrees);
            CreateSmallAsteroid(-radius, -RecycleSpawnInDegrees);
        }

        private void CreateSmallAsteroid(Vector2 point, float degrees)
        {
            var position = transform.position.ToVector2() + point;
            var rotation = GetRandomRotation(degrees);
            _gameFactory.CreateAsteroid(position, rotation, _recycle - 1, _recycle * RecycleSizeModifier);
        }

        private Quaternion GetRandomRotation(float maxDegrees)
        {
            var value = Random.value;
            var minRot = transform.rotation;
            var maxRot = minRot * quaternion.Euler(Vector3.forward * maxDegrees);
            return Quaternion.Lerp(minRot, maxRot, value);
        }
    }
}