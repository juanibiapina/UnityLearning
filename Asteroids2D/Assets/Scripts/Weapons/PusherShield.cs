using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherShield : MonoBehaviour {
    public GameObject prefab;
    public float cooldown = 3;

    float lastShotTime;

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        if (Time.time - lastShotTime > cooldown) {
            Instantiate(prefab, transform);
            lastShotTime = Time.time;
        }
    }
}
