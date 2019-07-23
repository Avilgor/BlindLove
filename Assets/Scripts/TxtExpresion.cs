using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TxtExpresion : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public GameObject bocadillo;
    Animator anim;

    bool up = false;
    bool down = false;
    bool next = true;

    int aux=0;

    private string []frases = {"I love this weapon!","Such a nice gun!","One less to go!","Just perfect <3","All I need <3","My favourite one <3"};

    void Start()
    {
        anim = bocadillo.GetComponent<Animator>();
        //txt.enabled = false;
        bocadillo.SetActive(false);
    }

    
    void Update()
    {
        if (next)
        {
            next = false;
            float nextTxt = Random.Range(5, 10);
            Debug.Log("Siguiente en:" + nextTxt);
            StartCoroutine(WaitTurn(nextTxt));
        }
        
        if (up)
        {
            up = false;
            show();
        }

        if (down)
        {
            down = false;
            hide();
        }
    }


    void show()
    {
        bocadillo.SetActive(true);       
        chooseText();
        StartCoroutine(turnOff(3f));
    }

    void hide()
    {
        //txt.enabled = false;
        anim.SetTrigger("Hide");
        StartCoroutine(HideBocadillo(2f));
    }

    void chooseText()
    {
        int decir = Random.Range(0, 6);//Cambiar al añadir o quitar frases!!

        if (aux == decir)
        {
            aux = decir;
            txt.text = frases[0];
            //txt.enabled = true;
        }
        else
        {
            aux = decir;
            txt.text = frases[decir];
            //txt.enabled = true;
        }
    }

    IEnumerator WaitTurn(float time)
    {
        yield return new WaitForSeconds(time);
        up = true;
    }

    IEnumerator turnOff(float time)
    {
        yield return new WaitForSeconds(time);
        down = true;
    }

    IEnumerator HideBocadillo(float time)
    {
        yield return new WaitForSeconds(time);
        bocadillo.SetActive(false);        
        next = true;
    }
}