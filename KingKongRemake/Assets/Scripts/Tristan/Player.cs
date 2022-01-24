using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = .050f;
    private Rigidbody2D rb;
    private bool cubeIsOnGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementMechanic();

        if (Input.GetButtonDown("Jump") && cubeIsOnGround == true)
        {
            JumpMechanic();
        }
    }

    private void MovementMechanic()
    {
        float xDirection = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);

        transform.position += moveDirection * speed;
    }

    private void JumpMechanic()
    {
        rb.AddForce(new Vector3(0, 8, 0), ForceMode2D.Impulse);
        cubeIsOnGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            cubeIsOnGround = true;
        }
    }
}
