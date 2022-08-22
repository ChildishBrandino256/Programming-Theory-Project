using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressRtoRestart : MenuManager
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadGame(); //ABSTRACTION, INHERITANCE
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu(); //ABSTRACTION, INHERITANCE
        }
    }
}
