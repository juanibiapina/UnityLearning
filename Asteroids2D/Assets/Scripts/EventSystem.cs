using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {
    public Action<GameObject> AsteroidDestroyed;
    public Action PlayerDied;
}
