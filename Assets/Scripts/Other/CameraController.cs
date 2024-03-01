using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    

    void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, -10);
    }
}
