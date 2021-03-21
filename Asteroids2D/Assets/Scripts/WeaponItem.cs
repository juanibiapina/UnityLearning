using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {
    public GameObject weaponPrefab;

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Player") {
            // self destruct
            Destroy(gameObject);

            // set weapon from prefab
            Player player = c.gameObject.GetComponent<Player>();
            player.SetWeapon(weaponPrefab);
        }
    }
}
