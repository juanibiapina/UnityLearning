using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletCooldown;

    float lastShotTime;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShootBullet();
        }
    }
    
    private void ShootBullet()
    {
        if (Time.time - lastShotTime > bulletCooldown)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastShotTime= Time.time;
        }
    }
}
