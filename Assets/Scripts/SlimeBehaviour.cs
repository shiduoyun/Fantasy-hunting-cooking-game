using System;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;

    Boolean jumping;

    [SerializeField]
    public int health = 5;




    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponentInParent<Rigidbody2D>();
        jumping = true;

    }

    void Update()
    {
        if (jumping == false)
        {
            Invoke("SlimeJump", UnityEngine.Random.Range(0.5f, 0.5f));

            jumping = true;
        }

    }

    /*void DisableCollider()
    {
        boxCollider.enabled = false;
    }*/

    void SlimeJump()
    {
        jumping = true;
        float xSpeed = 0;
        int jumpLeftOrRight = UnityEngine.Random.Range(1, 3);
        if (jumpLeftOrRight == 1)
        {
            xSpeed = UnityEngine.Random.Range(-5.0f, -3.0f);
        }
        else if (jumpLeftOrRight == 2)
        {
            xSpeed = UnityEngine.Random.Range(3.0f, 5.0f);
        }
        rigidBody.AddForce(new Vector2(xSpeed, UnityEngine.Random.Range(3.0f, 5.0f)), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && rigidBody.linearVelocityY == 0)
        {
            Invoke("ResetJump", 1f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && rigidBody.linearVelocityY == 0)
        {
            jumping = true;
        }
    }

    void ResetJump()
    {
        jumping = false;
    }
}