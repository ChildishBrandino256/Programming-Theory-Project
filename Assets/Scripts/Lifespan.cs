using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField] protected float lifespan;
    Transform sibling;
    [SerializeField] bool hasSibling;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Life());
        if (hasSibling)
        {
            sibling = transform.parent.GetChild(1);
        }
    }

    protected IEnumerator Life()
    {
        yield return new WaitForSeconds(lifespan);
        if (hasSibling)
        {
            if (!sibling.gameObject.activeSelf)
            {
                sibling.gameObject.SetActive(true);
            }
        }
        gameObject.SetActive(false);
    }
}
