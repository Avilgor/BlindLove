using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 target;
    float lifetime = 0;
    bool positiontracked;

    void Start()
    {
        var dir = target - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        positiontracked = false;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (!positiontracked)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
            print("position tracked");
            positiontracked = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, -0.2f);

        //transform.position = Vector3.MoveTowards(transform.position, target, -0.2f);



        target.x *= 1.5f;
        //target.y *= 1.5f;
        if (lifetime > 3)
        {
            Destroy(gameObject);
            positiontracked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag=="Suelo" || collision.gameObject.tag == "Obstaculo")
        {            
            Destroy(gameObject);
            positiontracked = false;
        }
    }
}
