using System;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    public float speed = 15f;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigidBody;

    public Transform FlameThrower;
    public Transform FireBalls;
    private Transform Weapon = null;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontalMove, 0f, 0f);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = (float) -2;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = (float) 2;
        }
        transform.localScale = characterScale;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, jumpSpeed);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (this.transform.localScale.x < 0)
            {
                Weapon = Instantiate(FlameThrower, new Vector3(0, 0, 0), Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Weapon = Instantiate(FlameThrower, new Vector3(0, 0, 0), Quaternion.identity);
            }
            //Weapon = Instantiate(FlameThrower, new Vector3(0, 0, 0), Quaternion.identity);
            Weapon.transform.parent = this.transform;
            Weapon.transform.localPosition = new Vector3((float)0.1, (float)-0.09, 0);
            Weapon.transform.localScale = this.transform.localScale / 3;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if(Weapon != null)
            {
                Destroy(Weapon.gameObject);
            }
        }
    }
}
