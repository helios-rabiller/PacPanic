using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedMultiplier =1.2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveDir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
    }
}   