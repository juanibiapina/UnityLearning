using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutUIController : MonoBehaviour
{
    public Text levelNumber;

    void Start()
    {
        levelNumber.text = Levels.Level().ToString();
    }

    void Update()
    {
        
    }
}
