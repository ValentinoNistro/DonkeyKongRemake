using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(gameObject);
    }
}
