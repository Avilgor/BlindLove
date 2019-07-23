using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    Rigidbody2D rb;
    bool damage = false;
    public int vida;
    public int t;

    public int invx;
    public int invy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && !damage)
        {
            //print("ha chocado con el enemigo");
            damage = true;
            rb.AddForce(new Vector2(-invx, invy), ForceMode2D.Impulse);
            vida -= 1;
            StartCoroutine(Invencibilidad());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("BulletMala") && !damage)
        {
            damage = true;
            rb.AddForce(new Vector2(-invx, invy), ForceMode2D.Impulse);
            vida -= 1;
            Destroy(collision.gameObject);
            StartCoroutine(Invencibilidad());
        }

        if (collision.gameObject.tag.Equals("Finish"))
        {
            SceneManager.LoadScene(4);
        }
    }

    /*private void FixedUpdate()
    {
        if (damage)
        {
            
            print("ha puesto la fuerza");
            damage = false;
        }
    }*/

    IEnumerator Invencibilidad()
    {       
        yield return new WaitForSeconds(t);
        damage = false;
    }
}
