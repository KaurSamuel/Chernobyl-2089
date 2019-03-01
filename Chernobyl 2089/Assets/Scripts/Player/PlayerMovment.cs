using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    public Animator Animator;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (horizontal != 0 && vertical != 0) // diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }


        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        float moving_total = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        Animator.SetFloat("Moving", moving_total);
    }
}
