using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject bullet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet b = bullet.GetComponent<Bullet>();
        if (collision.gameObject.CompareTag("damagable"))
        {
            Target t = collision.GetComponent<Target>();
            t.Die();
            b.Die();
        }
        else
        {
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Bullet b = bullet.GetComponent<Bullet>();
        if (collision.gameObject.CompareTag("damagable"))
        {
            Target t = collision.GetComponent<Target>();
            t.Die();
            b.Die();
        }
        else
        {
            b.Die();
        }
    }
}
