using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject animate;

    [SerializeField]
    GameObject MilkBottle;

    [SerializeField]
    Transform shotPoint;

    private float timeBetweenThrows;

    [SerializeField]
    float startTimeBetweenThrows;

    Animator animator;

    [SerializeField]
    Transform player;

    [SerializeField]
    float rangeDetect;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = animate.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float disttoPlayer = Vector2.Distance(transform.position, player.position);
        if(disttoPlayer < rangeDetect)
        {
            if(transform.position.x < player.position.x)
            {
                if(timeBetweenThrows <= 0)
                {
                    Instantiate(MilkBottle, shotPoint.position, transform.rotation);
                    transform.localScale = new Vector2(2, 2);
                    timeBetweenThrows = startTimeBetweenThrows;
                }
                else
                {
                    timeBetweenThrows -= Time.deltaTime;
                }
            }
            else
            {
                if (timeBetweenThrows <= 0)
                {
                    Instantiate(MilkBottle, shotPoint.position, transform.rotation);
                    transform.localScale = new Vector2(-2, 2);
                    timeBetweenThrows = startTimeBetweenThrows;
                }
                else
                {
                    timeBetweenThrows -= Time.deltaTime;
                }
            }
        }
        else
        {
            rb2d.velocity = Vector2.zero;
            animator.Play("Enemy_Idle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FlameThrower")
        {
            animator.Play("Enemy_Died");
            Destroy(gameObject, 1f);
        }
    }
}
