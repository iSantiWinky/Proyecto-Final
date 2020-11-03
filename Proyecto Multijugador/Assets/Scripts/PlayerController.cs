using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float speed = 1f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W)) transform.Translate(Vector2.up * speed);
            if (Input.GetKey(KeyCode.S)) transform.Translate(Vector2.down * speed);
            if (Input.GetKey(KeyCode.D)) transform.Translate(Vector2.right * speed);
            if (Input.GetKey(KeyCode.A)) transform.Translate(Vector2.left * speed);

        }
    }
}
