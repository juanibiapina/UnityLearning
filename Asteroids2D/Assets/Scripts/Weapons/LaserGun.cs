using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour {
    public GameObject laserPrefab;
    public float cooldown = 0.1f;

    float lastShotTime;

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            ShootLaser();
        }
    }

    private void ShootLaser() {
        if (Time.time - lastShotTime > cooldown) {
            Instantiate(laserPrefab, transform.position, transform.rotation);
            lastShotTime = Time.time;
        }
    }
}
