using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float sEntretiros;
    public Transform gunPoint;
    public GameObject bulletPrefab;
    bool retroceso = false;
    bool canShoot = true;
    int modoDisp = 0;
    Animator anim;

    // Update is called once per frame

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Update()
    {       
        if (Input.GetMouseButtonDown(1))
        {
            if (!retroceso)
                retroceso = true;
            else if (retroceso)
                retroceso = false;

        }
        if (Input.GetMouseButtonDown(0) && !retroceso && canShoot && (anim.GetBool("Movimiento") == false) || (Input.GetKeyDown (KeyCode.Space) && !retroceso && canShoot) && (anim.GetBool("Movimiento") == false))
        {
            StartCoroutine(Shoot());
        }

        else if (Input.GetMouseButtonDown(0) && retroceso && canShoot && (anim.GetBool("Movimiento") == false) || (Input.GetKeyDown(KeyCode.Space) && retroceso && canShoot) && (anim.GetBool("Movimiento") == false))
        {                     
            StartCoroutine (Shoot());
            Movimiento movimiento = GetComponent<Movimiento>();
            movimiento.Retroceso();

        }

        else if (Input.GetMouseButtonDown(0) && !canShoot || (Input.GetKeyDown(KeyCode.Space)&& !canShoot))
        {
            return;
        }
    }

    IEnumerator Shoot()
    {
        modoDisp = Random.Range(0, 8);
        switch (modoDisp)
        {
            case 0: //Doble tiro
                Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
                StartCoroutine(Dual());
                break;
            case 1: break; //No dispara
            /*case 2:
                Transform Rotacion = gunPoint.transform;
                Rotacion.Rotate(0, 90, 0);
                Instantiate(bulletPrefab, gunPoint.transform.position, Rotacion.rotation); break;  //Desvio de la bala*/
            default: Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation); break;
        }
   
        canShoot = false;
        yield return new WaitForSeconds(sEntretiros);              
        canShoot = true;
    }

    IEnumerator Dual()
    {        
        yield return new WaitForSeconds(0.5f);
        Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
    }
}
