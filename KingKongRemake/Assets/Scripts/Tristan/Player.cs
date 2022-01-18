using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = .01f;
    void Start()
    {

    }

    void Update()
    {
        MovementMechanic();
    }

    private void MovementMechanic()
    {
        float xDirection = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);

        transform.position += moveDirection * speed;
    }
}
