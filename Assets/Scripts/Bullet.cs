using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer;
    public float boost;
    public GameObject exlpode;
    public GameObject exParticles;
    Rigidbody2D rb;
    public LayerMask Default;
    public LayerMask Ground;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.layer = Default;
    }
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            exlpode.SetActive(true);
        }
    }
    public void Die()
    {
        GameObject particles = Instantiate(exParticles, transform.position, transform.rotation);
        Destroy(particles, 1f);
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if(collision.gameObject.CompareTag("player1"))
        {
            rb.AddForce(transform.up * boost, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("W");
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletBoost"))
        {
            rb.AddForce(transform.up * boost, ForceMode2D.Impulse);
        }
    }
}
