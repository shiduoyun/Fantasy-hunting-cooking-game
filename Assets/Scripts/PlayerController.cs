using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    public float attackDuration = 0.5f;

    public int playerHealth;
    Rigidbody2D rigidBody;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction attackAction;

    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite idleSprite;
    [SerializeField]
    Sprite attackSprite;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        spriteRenderer.sprite = idleSprite;
        playerHealth = 3;

        // float height = Camera.main.orthographicSize * 2;
        // float width = height * Camera.main.aspect;

        // Debug.Log("Camera Width: " + width);
        // Debug.Log("Camera Height: " + height);
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody.linearVelocityX = moveAction.ReadValue<Vector2>().x * speed;
        if (rigidBody.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (rigidBody.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;

        }

        if (rigidBody.linearVelocityY == 0) //check for already falling/jumping; reprogram later to check if grounded
        {
            if (jumpAction.WasPressedThisFrame())
            {
                rigidBody.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
            }
        }

        if (attackAction.WasPressedThisFrame())
        {
            spriteRenderer.sprite = attackSprite;
            Invoke("resetSprite", attackDuration);
        }

    }
    void resetSprite()
    {
        spriteRenderer.sprite = idleSprite;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }
}
