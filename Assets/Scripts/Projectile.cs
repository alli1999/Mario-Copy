using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private Transform player;
    private Vector2 target;
    private Animator animation;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Instantiate(text, other.transform.position, Quaternion.Euler(0, 0, 0));
            animation = other.gameObject.GetComponent<Animator>();
            animation.Play("Player_Dead");
            float length = animation.GetCurrentAnimatorStateInfo(0).length;
            Destroy(other.gameObject, length);
            UnityEngine.Debug.Log("Hit");
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
