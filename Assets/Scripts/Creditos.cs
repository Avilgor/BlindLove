using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    bool ok = true;

    void Start()
    {
        StartCoroutine(SubirCreditos(14f));
    }

    private void Update()
    {
        if (ok)
        { gameObject.transform.Translate(0, 0.02f, 0); }
        else { SceneManager.LoadScene(0); }
        
    }

    IEnumerator SubirCreditos(float time)
    {
        yield return new WaitForSeconds(time);
        ok = false;
    }
}
