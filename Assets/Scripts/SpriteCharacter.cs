using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCharacter : MonoBehaviour {
    public SpriteRenderer sprite;

    private Rigidbody rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        sprite.transform.rotation = Camera.main.transform.rotation;
    }

    private void Update() {
        sprite.flipX = rb.velocity.x switch {
            < 0 => true,
            > 0 => false,
            _ => sprite.flipX
        };
    }
}