using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public LayerMask playerLayer;
    public GameObject weaponHolder;
    public Weapon weapon;

    private GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {

    }

    void Update() {
        // try to attack player if in range
        if (player != null) {
            float distance = (player.transform.position - transform.position).magnitude;

            if (distance < 10) {
                Attack();
                return;
            }
        }
    }

    private void Attack() {
        weaponHolder.transform.LookAt(player.transform.position);
        weapon.Shoot();
    }
}
