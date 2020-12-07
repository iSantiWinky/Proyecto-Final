using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D mRigidbody2D;
    public float speed = 1f;
    public bool isGrounded = false;

    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;
    public KeyCode moveKey;

    public HealthBar healthBar;

    public float hitPoints;
    private float maxPoints = 10;

    public GameObject p1wins;


    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();

        hitPoints = maxPoints;


        turnSystem = GameObject.Find("Turn-basedSystem").GetComponent<TurnSystem>();

        foreach (TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }
    }

    void Update()
    {
        isTurn = turnClass.isTurn;

        if (isTurn)
        {
            Jump();
            Move();
            if (Input.GetKeyDown(moveKey))
            {
                isTurn = false;
                turnClass.isTurn = isTurn;
                turnClass.wasTurnPrev = true;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        if (hitPoints == 0)
        {
            Destroy(gameObject);
            p1wins.SetActive(true);
        }
    }
}
