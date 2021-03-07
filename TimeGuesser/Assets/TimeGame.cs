using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    public int roundDelayTime = 3;
    bool roundStarted;
    float startTime;
    int waitTime;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        if (!roundStarted) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            InputReceived();
        }
    }

    void InputReceived() {
        float waited = Time.time - startTime;
        float error = Mathf.Abs(waitTime - waited);

        print("You waited for " + waited + " seconds. That's " + error + "seconds off");

        Reset();
    }

    void Reset() {
        roundStarted = false;
        print("Get ready to start in " + roundDelayTime + " seconds");
        Invoke("StartDelayTime", roundDelayTime);
    }

    void StartDelayTime() {
        roundStarted = true;
        startTime = Time.time;
        waitTime = 10;
        print("Press space in " + waitTime + " seconds");
    }
}
