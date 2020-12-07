using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -3f, 3f),
                                        transform.position.y,
                                        transform.position.z);
    }
}
