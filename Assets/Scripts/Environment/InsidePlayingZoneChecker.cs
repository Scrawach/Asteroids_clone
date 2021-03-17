using System;
using UnityEngine;

namespace Environment
{
    public class InsidePlayingZoneChecker : MonoBehaviour
    {
        private Rect _playingZone;

        public void Construct(Rect playingZone) => 
            _playingZone = playingZone;

        private void Update()
        {
            if (transform.position.InsideZone(_playingZone.min, _playingZone.max) == false)
                Destroy(gameObject);
        }
    }
}