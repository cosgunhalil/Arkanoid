using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Vector3 finalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        finalVelocity = rigidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        float speed = finalVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(finalVelocity.normalized, other.GetContact(0).normal);
        rigidBody.velocity = direction * Mathf.Max(speed, 0f);
    }
}