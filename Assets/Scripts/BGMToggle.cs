using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BGMToggle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        state = true;    
    }

    private void Update()
    {
        if (state)
        {
            text.text = "BGM off";
        }
        if (!state)
        {
            text.text = "BGM on";
        }
    }

    public void Toggle() //ABSTRACTION
    {
        state = !state;
    }
}
