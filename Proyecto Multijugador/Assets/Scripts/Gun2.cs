using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public GameObject sword;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberPoints;
    public float spacePoints;
    Vector2 direction;

    public TurnClass turnClass;
    public bool isTurn = false;
    public KeyCode moveKey;

    private void Start()
    {
        points = new GameObject[numberPoints];
        for (int i = 0; i < numberPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        Vector2 bulletPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bulletPosition;
        transform.up = direction;

        for (int i = 0; i < numberPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spacePoints);
        }
    }

    void Shoot()
    {
        GameObject newSword = Instantiate(sword, shotPoint.position, shotPoint.rotation);
        newSword.GetComponent<Rigidbody2D>().velocity = transform.up * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
