using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissle : MonoBehaviour
{
    private void OnEnable()
    {
        if (!transform.GetChild(0).gameObject.activeSelf && !transform.GetChild(1).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!transform.GetChild(0).gameObject.activeSelf && !transform.GetChild(1).gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
