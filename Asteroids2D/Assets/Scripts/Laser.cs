using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float thrust;

    public float lifetime; void Start()
    {
        Destroy(gameObject, lifetime);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * thrust);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
