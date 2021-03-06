using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = .020f;
    public float jumpHeight = 4f;
    private Rigidbody2D rb;
    private bool cubeIsOnGround = false;
    public Animator animatorPlayer;
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
            animatorPlayer.SetBool("IsJumping", true);
        }
    }

    private void MovementMechanic()
    {
        float xDirection = Input.GetAxis("Horizontal");

        animatorPlayer.SetFloat("Speed", Mathf.Abs(xDirection));

        Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);

        transform.position += moveDirection * speed;

        if(xDirection < 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }
        else if(xDirection > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
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
            animatorPlayer.SetBool("IsJumping", false);
        }

        if (collision.gameObject.tag == "Princes")
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag == "Barrel")
        {
            SceneManager.LoadScene(0);
        }
    }
}
