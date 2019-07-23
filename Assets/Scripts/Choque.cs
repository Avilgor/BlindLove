using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{

    public bool inv;
    public float sinvencibilidad;

    // Start is called before the first frame update
    void Start()
    {
        inv = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inv == true)
        {
            StartCoroutine (Invencibilidad());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("ha chocado con el prota");
            inv = true;
        }
    }

    IEnumerator Invencibilidad()
    {
        Physics2D.IgnoreLayerCollision(0, 10, inv);
        yield return new WaitForSeconds(sinvencibilidad);
        inv = false;
        Physics2D.IgnoreLayerCollision(0, 10, inv);

    }
    
}
