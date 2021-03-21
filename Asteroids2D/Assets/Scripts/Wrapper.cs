using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour {
    Vector2 screenHalfSize;
    Vector2 halfSize;

    void Start() {
        CalculateScreenHalfSize();
        CalculateSize();
    }

    void Update() {
        WrapAround();
    }

    private void CalculateSize() {
        halfSize = new Vector2(transform.localScale.x / 2, transform.localScale.y / 2);
    }

    private void WrapAround() {
        Vector2 pos = transform.position;

        if (pos.x < -screenHalfSize.x - halfSize.x) {
            pos.x = screenHalfSize.x + halfSize.x;
        } else if (pos.x > screenHalfSize.x + halfSize.x) {
            pos.x = -screenHalfSize.x - halfSize.x;
        }

        if (pos.y < -screenHalfSize.y - halfSize.y) {
            pos.y = screenHalfSize.y + halfSize.y;
        } else if (pos.y > screenHalfSize.y + halfSize.y) {
            pos.y = -screenHalfSize.y - halfSize.y;
        }

        transform.position = pos;
    }

    void CalculateScreenHalfSize() {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
}
