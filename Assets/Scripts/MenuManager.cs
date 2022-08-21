using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        Invoke(nameof(LoadGame), 0.3f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    protected void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
