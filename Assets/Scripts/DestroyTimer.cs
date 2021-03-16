using System;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    private float _time;

    private void Start() => 
        Destroy(gameObject, _time);
}