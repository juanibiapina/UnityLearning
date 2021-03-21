using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject projectile;
    public float cooldown = 3;

    float lastShotTime;

    public void Shoot() {
        if (Time.time - lastShotTime > cooldown) {
            Instantiate(projectile, transform);
            lastShotTime = Time.time;
        }
    }
}
