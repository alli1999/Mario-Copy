using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float length, startPosition;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if(temp > startPosition + length - 1)
        {
            startPosition += length;
        }
        else if(temp < startPosition - length + 1){
            startPosition -= length;
        }
    }
}
