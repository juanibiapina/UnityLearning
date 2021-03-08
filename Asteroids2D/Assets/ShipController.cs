using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float rotationSpeed;
    public float thrust;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float rotationDirection = Input.GetAxisRaw("Horizontal");

        body.MoveRotation(body.rotation - (rotationSpeed * rotationDirection * Time.deltaTime));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddRelativeForce(Vector2.up * thrust);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }
}
