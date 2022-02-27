using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject text;
    Boolean textOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector3 pos = new Vector3(other.transform.position.x, (float) -2.38, other.transform.position.z);
            Animator animator = other.GetComponent<Animator>();
            animator.Play("Player_Dead");
            Destroy(other.gameObject, 1f);
            if (!textOn)
            {
                Instantiate(text, pos, Quaternion.Euler(0, 0, 0));
                textOn = true;
            }
        }
    }
}
