using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color origColor;
    [SerializeField] Color flashColor;
    float flashTime = .08f;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        origColor = meshRenderer.material.color;
    }

    public IEnumerator Flash()
    {
        meshRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material.color = origColor;
    }
}
