using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        ParticleSystem p = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = p.shape;
        shape.radius = Camera.main.aspect * Camera.main.orthographicSize;
        p.Play();
    }

    // Update is called once per frame
    void Update() {

    }
}
