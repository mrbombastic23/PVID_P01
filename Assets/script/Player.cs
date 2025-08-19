using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool gransalto = true;
    public float correrSpeed = 2;
    public float saltoSpeed = 3;
    public float multiplicador = 2f;
    public float bajo_multiplicador = 1f;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(correrSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-correrSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("space") && Ground.isGround)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, saltoSpeed);
        }

        if (gransalto)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (multiplicador) * Time.deltaTime;
            }

            if (rb2D.velocity.y > 0 && !Input.GetKey("w"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (bajo_multiplicador) * Time.deltaTime;
            }
        }
    }
}