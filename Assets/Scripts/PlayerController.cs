using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    Rigidbody2D rigidBody;
    InputAction moveAction;
    InputAction jumpAction;
    public GameObject coinPrefab;

    public UnityEvent onMysteryBoxActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocityX = moveAction.ReadValue<Vector2>().x * speed;

        if (rigidBody.linearVelocityY == 0) //check for already falling/jumping
        {
            if (jumpAction.WasPressedThisFrame())
            {
                rigidBody.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
            }
        }
    }
}
