using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Entregas : MonoBehaviour
{

    public GameObject[] pedidosCanvas;
    private GameObject objetoRecebido;
    public GameObject GM;

    private void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Pedido1 scriptColisor = other.gameObject.GetComponent<Pedido1>();
        GameManager scriptGM = other.gameObject.GetComponent<GameManager>();
        objetoRecebido = other.gameObject;
        if (!other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("ItemRequisito") || other.gameObject.CompareTag("Ingrediente"))
            {
                var foiPedido = CheckObjectID();
                if (foiPedido)
                {
                    StartCoroutine(MandarMensagem());
                    Destroy(objetoRecebido);
                    objetoRecebido.transform.parent = null;
                    objetoRecebido = null;
                    GameManager.Pontos += 30;
                    GameManager.pedidosCheio = false;
                    Pegador.PodePegar1 = true;
                }
                else if (!foiPedido)
                {
                    GameManager.Pontos -= 20;
                    pedidoErrado();
                }
            }
            else if (other.gameObject.CompareTag("Ingrediente"))
            {
                GameManager.Pontos -= 20;
                pedidoErrado();
            }
        }
    }
    
    private void pedidoErrado()
    {
        Destroy(objetoRecebido);
        objetoRecebido.transform.parent = null;
        objetoRecebido = null;
        Pegador.PodePegar1 = true;
    }

    public bool CheckObjectID()
    {
        for (int i = 0; i < pedidosCanvas.Length; i++)
        {
            if (pedidosCanvas[i].gameObject.name == objetoRecebido.name)
            {
                pedidosCanvas[i].gameObject.SetActive(false);
                return true;
            }
        }

        return false;
    }

    IEnumerator MandarMensagem()
    {
        yield return new WaitForSeconds(1);
        GM.SendMessage("QualPedido");
    }
}