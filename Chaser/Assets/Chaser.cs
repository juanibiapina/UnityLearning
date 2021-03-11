using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float speed = 5;
    public float attackRange = 1.5f;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 displacement = target.position - transform.position;
        Vector3 dir = displacement.normalized;
        float distance = displacement.magnitude;

        if (distance > attackRange) {
            Vector3 offset = dir * (speed * Time.deltaTime);
            Debug.DrawRay(transform.position, dir, Color.red);

        transform.Translate(offset);
        }
    }
}
