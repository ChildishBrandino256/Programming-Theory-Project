using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSibling : MonoBehaviour //I'm genuinely not sure if there was a better way i could have done this
    
{
    Transform sibling;
    private void OnEnable()
    {
        sibling = transform.parent.GetChild(1);
    }
    private void OnDisable()
    {
        if(!sibling.gameObject.activeSelf)
        {
            sibling.gameObject.SetActive(true);
        }
    }
}
