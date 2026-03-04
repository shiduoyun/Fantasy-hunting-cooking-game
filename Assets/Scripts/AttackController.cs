
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class AttackController : MonoBehaviour
{
    InputAction attackAction;
    BoxCollider2D boxCollider;

    Rigidbody2D parentBody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        parentBody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            boxCollider.enabled = true;
            Invoke("disableCollider", 2);
        }

        if (parentBody.linearVelocityX < 0)
        {
            transform.localPosition = new Vector3(-0.024f, 0.5250067f, 0f); //CHANGE THESE VALUES WHEN SPRITES ARE CHANGED!!!
        }
        if (parentBody.linearVelocityX > 0)
        {
            transform.localPosition = new Vector3(0.1738255f, 0.5250067f, 0f);//CHANGE THESE VALUES WHEN SPRITES ARE CHANGED!!!

        }
    }

    void disableCollider()
    {
        boxCollider.enabled = false;
    }
}
