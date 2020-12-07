using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<PlayerController>();
        if(enemy)
        {
            enemy.TakeHit(1);
        }

        var enemy2 = collision.collider.GetComponent<PlayerController2>();
        if (enemy2)
        {
            enemy.TakeHit(1);
        }

        Destroy(gameObject);
    }
}
