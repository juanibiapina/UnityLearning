using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunItem : MonoBehaviour
{
    public GameObject laserGunPrefab;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            // self destruct
            Destroy(gameObject);

            Player player = c.gameObject.GetComponent<Player>();
            player.SetWeapon(laserGunPrefab);
        }
    }
}
