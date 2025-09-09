using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    float filled;
    float cut;
    bool isBeingCrushed;
    Rigidbody2D rb;
    public Vector3 shrink;
    public float MaxSize;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        filled = rb.mass = rb.mass / 1;
        cut = rb.mass = rb.mass / 4;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null && p.canPush)
        {
            rb.mass = cut;
        }
        else
        {
            rb.mass = filled;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null && p.canPush)
        {
            rb.mass = cut;
        }
        else
        {
            rb.mass = filled;
        }
    }
    private void OnTriggerStay2D(Collider2D Tcollision)
    {
        Player p = Tcollision.GetComponent<Player>();
        if (Tcollision.CompareTag("player0") && p.canPush && rb.transform.localScale.y <= MaxSize)
        {
           // Destroy(gameObject);
            rb.transform.localScale -= shrink;
        }
        else if (Tcollision.CompareTag("player2") && p.canPush && rb.transform.localScale.y <= MaxSize)
        {
            // Destroy(gameObject);
            rb.transform.localScale -= shrink;
        }
        else
        {
            isBeingCrushed = false;
        }
    }
    private void Update()
    {
        //if(tr.localScale >= stopShrinkSize)
        //{
        if (isBeingCrushed == true)
        {
        }
        if(rb.transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }
        //}
       // isBeingCrushed = false;
    }
}
