using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveH : MonoBehaviour
{
    public float speed;
    float xBound = 16;
    [SerializeField] bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Bounds();
        
    }

    protected void Bounds()
    {
        float xPosition = transform.position.x;
        if (xPosition < -xBound || xPosition > xBound)
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
