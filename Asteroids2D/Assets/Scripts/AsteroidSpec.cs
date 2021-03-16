using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpec
{
    public float size;
    public float speed;
    public int numberOfChildren;
    public AsteroidSpec childSpec;

    public AsteroidSpec(float size, float speed, int numberOfChildren, AsteroidSpec childSpec) {
        this.size = size;
        this.speed = speed;
        this.numberOfChildren = numberOfChildren;
        this.childSpec = childSpec;
    }
}
