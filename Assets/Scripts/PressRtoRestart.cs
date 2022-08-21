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
            LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }
}
