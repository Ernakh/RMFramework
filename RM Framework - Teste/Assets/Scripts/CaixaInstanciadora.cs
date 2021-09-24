using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaInstanciadora : MonoBehaviour
{
    public bool playerNoLocal = false;
    public bool podeInstanciar = true;
    public GameObject objetoDesejado;

    public GameObject player1;

    private void Start()
    {
        player1 = GameObject.Find("Pegador");
    }

    private void OnTriggerStay(Collider other) //pelo jeito vou ter que fazer uma caixa  instanciador pra cada item ne.
    {
        if (other.gameObject.CompareTag("ItemRequisito") || other.gameObject.CompareTag("Ingrediente"))
        {
            podeInstanciar = false;
        }
        else if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            playerNoLocal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            playerNoLocal = false;
        }
        if (other.gameObject.CompareTag("ItemRequisito") || other.gameObject.CompareTag("Ingrediente"))
        {
            podeInstanciar = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && podeInstanciar && playerNoLocal)
        {
            StartCoroutine(Instanciador1());
        }
    }

    IEnumerator Instanciador1()
    {
        if (podeInstanciar)
        {
            podeInstanciar = false;
            Instantiate(objetoDesejado, new Vector3(this.transform.position.x, this.transform.position.y + 1.3f, this.transform.position.z), objetoDesejado.transform.rotation);
            yield return new WaitForSeconds(1.5f);
            podeInstanciar = true;
        }
    }
}
