using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Pedido1 : MonoBehaviour
{
    public int idPedido;
    private bool estouNaCaixaAcao;

    private void Update()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.transform.position = transform.parent.position;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else gameObject.GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("CaixaDeAcao"))
        {
            estouNaCaixaAcao = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CaixaDeAcao"))
        {
            estouNaCaixaAcao = false;
        }
    }
}
