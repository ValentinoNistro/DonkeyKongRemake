using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = .050f;
    public float jumpHeight = 4f;
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
        rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Impulse);
        cubeIsOnGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            cubeIsOnGround = true;
        }

        if (collision.gameObject.tag == "Princes")
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.tag == "Barrel")
        {
            SceneManager.LoadScene(2);
        }
    }
}
