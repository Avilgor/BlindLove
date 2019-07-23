using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;
    public int bulletdamage;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Physics2D.IgnoreLayerCollision(0, 10);
    }

    private void OnTriggerEnter2D(Collider2D Hitinfo)
    {
        //print("la bala ha chocado");
        Enemy enemy = Hitinfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(bulletdamage);
        }
        Physics2D.IgnoreLayerCollision(0, 10, false);
        Destroy(gameObject);
    }
}