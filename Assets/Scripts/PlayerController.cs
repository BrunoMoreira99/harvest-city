using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float baseSpeed = 1;
    [SerializeField] private Animator animator;
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isSprinting;
    private static readonly int AnimMoveSpeed = Animator.StringToHash("moveSpeed");

    // Start is called before the first frame update
    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        animator.SetFloat(AnimMoveSpeed, rb.velocity.magnitude / baseSpeed);
    }

    private void FixedUpdate() {
        moveInput *= CurrentSpeed;
        rb.velocity = new Vector3(moveInput.x, 0, moveInput.y);
    }
    
    private float CurrentSpeed => isSprinting ? baseSpeed * 1.5f : baseSpeed;
}