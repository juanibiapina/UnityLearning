using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.0f);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 400);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
