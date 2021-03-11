using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    public float thrust;
    public ParticleSystem afterburnerLeft;
    public ParticleSystem afterburnerRight;

    public event System.Action OnPlayerDeath;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        float rotationDirection = Input.GetAxisRaw("Horizontal");

        body.MoveRotation(body.rotation - (rotationSpeed * rotationDirection * Time.deltaTime));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddRelativeForce(Vector2.up * thrust);
            afterburnerLeft.Play();
            afterburnerRight.Play();
        } else {
            afterburnerLeft.Stop();
            afterburnerRight.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
        }
    }
}
