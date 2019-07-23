using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IADetection : MonoBehaviour
{
    GameObject target;
    public float range=0;
    bool ok = true;
    public GameObject Bullet,gun;
    public bool rotate;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rotate = false;

    }

    private void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        
        if (distance < range && ok)
        {
            reaction();
        }

        if (target.transform.position.x > transform.position.x && !rotate)
        {
            transform.Rotate(0f, 180f, 0f);
            rotate = true;
        }

        else if (target.transform.position.x < transform.position.x && rotate)
        {
            transform.Rotate(0f, 180f, 0f);
            rotate = false;
        }

    }

    private void reaction()
    {
        ok = false;
        //gameObject.transform.Translate(0, 1f, 0);          
        Instantiate(Bullet, gun.transform.position, gun.transform.rotation);
        StartCoroutine(Relax(3f));     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator Relax(float time)
    {
        yield return new WaitForSeconds(time);
        ok = true;
    }
}
