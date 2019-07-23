using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLife : MonoBehaviour
{
    public GameObject player;
    public GameObject []corazones = new GameObject[3];

    void Start()
    {
        corazones[0].SetActive(true);
        corazones[1].SetActive(true);
        corazones[2].SetActive(true);
    }

    
    void Update()
    {
        if (player.GetComponentInChildren<Vida>().vida == 2)
        {
            corazones[2].SetActive(false);
        }

        if (player.GetComponentInChildren<Vida>().vida == 1)
        {
            corazones[1].SetActive(false);
        }

        if (player.GetComponentInChildren<Vida>().vida == 0)
        {
            corazones[0].SetActive(false);
        }
    }
}
