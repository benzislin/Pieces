using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    float move;
    public bool canShoot = false;
    public bool canMove = false;
    public bool canJump = false;
    public bool canPush = false;
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;
    public GameObject bulletPrefab;
    public float bulletForce;
    public Transform firePoint;
    public ParticleSystem moveParticles;
    public ParticleSystem jumpParticles;
    bool right = true;
    bool isMoving;
    bool landed;
    public float springForce;
    GameObject winMenu;
    public bool active;
    public AudioSource walk;
    public AudioSource jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winMenu = GameObject.FindGameObjectWithTag("WinMenu");
        if (canMove)
        {
            moveParticles.Stop();
            jumpParticles.Stop();
        }
        if (canJump)
        {
            jumpParticles.Stop();
        }
        if (canMove)
        {
            winMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (canJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpParticles.Play();
                    jump.Play();
                }
            }
            if (canShoot)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
        }
        if (canMove && isMoving == true && isGrounded == true)
        {
            moveParticles.Play();
            walk.Stop();
        }
        else if (canMove && isMoving == false && isGrounded == true)
        {
            StartCoroutine(Walk());
        }
        if(canMove && isGrounded == false)
        {
            moveParticles.Stop();
        }
        if(move == 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        //Debug.Log(move);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        landed = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        if (right == false && move > 0)
        {
            Flip();
        }
        if (right == true && move < 0)
        {
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player2"))
        {
            canPush = true;
        }
        else if(collision.CompareTag("player3"))
        {
            canMove = true;
        }
        else if(collision.CompareTag("player4"))
        {
            canShoot = true;
        }
        else if (collision.CompareTag("player1"))
        {
            canJump = true;
        }
        if(collision.CompareTag("player0"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Spring pad"))
        {
            rb.AddForce(transform.up * springForce, ForceMode2D.Impulse);
        }
        if (collision.CompareTag("Spring pad 2"))
        {
            rb.AddForce(transform.up * springForce, ForceMode2D.Impulse);
            GameObject spring2 = collision.gameObject;
            Destroy(spring2);
        }
        if (collision.CompareTag("Win") && canMove && canJump && canPush && canShoot)
        {
            Debug.Log("WIN");
            //winMenu = GameObject.FindGameObjectWithTag("WinMenu");
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Spring pad"))
        {
            rb.AddForce(transform.up * springForce, ForceMode2D.Impulse);
        }
        if (collision.CompareTag("Spring pad 2"))
        {
            rb.AddForce(transform.up * springForce, ForceMode2D.Impulse);
            GameObject spring2 = collision.gameObject;
            Destroy(spring2, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == ground)
        {
            jumpParticles.Play();
            Debug.Log("W");
        }
    }
    void Flip()
    {
        right = !right;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    IEnumerator Walk()
    {
        walk.Play();
        yield return new WaitForSeconds(0.1f);
        walk.Stop();
    }
}
