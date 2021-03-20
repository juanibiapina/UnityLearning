using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject defaultWeapon;
    public float rotationSpeed;
    public float thrust;
    public ParticleSystem afterburnerLeft;
    public ParticleSystem afterburnerRight;

    public GameObject explosion;

    public event System.Action OnPlayerDeath;

    Rigidbody2D body;
    AudioSource booster;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        booster = GetComponent<AudioSource>();
        Instantiate(defaultWeapon, transform);
    }

    void FixedUpdate()
    {
        float rotationDirection = Input.GetAxisRaw("Horizontal");

        body.MoveRotation(body.rotation - (rotationSpeed * rotationDirection * Time.deltaTime));

        float input = Input.GetAxisRaw("Vertical");
        input = Mathf.Clamp(input, 0, 1);
        if (input > 0)
        {
            body.AddRelativeForce(Vector2.up * thrust);
            afterburnerLeft.Play();
            afterburnerRight.Play();
            if (!booster.isPlaying)
            {
                booster.Play();
            }
        }
        else
        {
            afterburnerLeft.Stop();
            afterburnerRight.Stop();
            if (booster.isPlaying)
            {
                booster.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
        }
    }
}
