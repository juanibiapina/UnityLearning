using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject defaultWeapon;
    public float rotationSpeed;
    public float thrust;
    public ParticleSystem afterburnerLeft;
    public ParticleSystem afterburnerRight;

    public GameObject explosion;

    public event System.Action OnPlayerDeath;

    Rigidbody2D body;
    AudioSource booster;

    List<Weapon> weapons = new List<Weapon>();
    int currentWeapon;

    public void AddWeapon(GameObject weaponPrefab) {
        GameObject weapon = Instantiate(weaponPrefab, transform);
        Weapon weaponScript = weapon.GetComponent<Weapon>();

        weapons.Add(weaponScript);
    }

    void Start() {
        body = GetComponent<Rigidbody2D>();
        booster = GetComponent<AudioSource>();
        AddWeapon(defaultWeapon);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            weapons[currentWeapon].Shoot();
        }

        if (Input.GetKey(KeyCode.Alpha1)) {
            if (weapons.Count >= 1) {
                currentWeapon = 0;
            }
        }

        if (Input.GetKey(KeyCode.Alpha2)) {
            if (weapons.Count >= 2) {
                currentWeapon = 1;
            }
        }

        if (Input.GetKey(KeyCode.Alpha3)) {
            if (weapons.Count >= 3) {
                currentWeapon = 2;
            }
        }
    }

    void FixedUpdate() {
        float rotationDirection = Input.GetAxisRaw("Horizontal");

        body.MoveRotation(body.rotation - (rotationSpeed * rotationDirection * Time.deltaTime));

        float input = Input.GetAxisRaw("Vertical");
        input = Mathf.Clamp(input, 0, 1);
        if (input > 0) {
            body.AddRelativeForce(Vector2.up * thrust);
            afterburnerLeft.Play();
            afterburnerRight.Play();
            if (!booster.isPlaying) {
                booster.Play();
            }
        } else {
            afterburnerLeft.Stop();
            afterburnerRight.Stop();
            if (booster.isPlaying) {
                booster.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Asteroid") {
            Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
        }
    }
}
