using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public KeyCode trigger = KeyCode.Space;
    public float power = 5.0f;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool active = Input.GetKey(trigger);
        
        if (active) {
            body.AddRelativeForce(Vector3.up * power);
        }
    }
}
