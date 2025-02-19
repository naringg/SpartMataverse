using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;

    [SerializeField] private float speed = 3f;

    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * speed;
        animator.SetBool(IsMoving, movementDirection.magnitude > 0);
        if (movementDirection.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementDirection.x), 1, 1);
        }
    }
}
