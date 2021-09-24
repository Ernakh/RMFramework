using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class TrocarCor : MonoBehaviour
{
    public GameObject objetoFinal;
    public GameObject corPia;
    public GameObject spawnplace;
    private Material _corPia;
    private Transform tintaNaPia;

    [SerializeField]public int numeroItens = 0;

    public static bool playerNaCaixa = false;
    public static bool player2NaCaixa = false;
    public static bool possoFazerAcao = false;
    float timer = 0;
    float holdDur = 3f;

    private Transform objetoColocado1;
    private Transform objetoColocado2;
    public GameObject objetoColocado1BOLHA;
    public GameObject objetoColocado2BOLHA;

    int idObjeto1;
    int idObjeto2;

    [Header("Colocar aqui a soma do primeiro e primeiro pedido")] // vermelho
    public Material pedido1Final;
    [Header("Colocar aqui a soma do segundo e segundo pedido")] // amarelo
    public Material pedido2Final;
    [Header("Colocar aqui a soma do terceiro e terceiro pedido")] // azul
    public Material pedido3Final;
    [Header("Colocar aqui a soma do primeiro e segundo pedido")] // laranja
    public Material pedido1e2Final;
    [Header("Colocar aqui a soma do primeiro e terceiro pedido")] // violeta
    public Material pedido1e3Final;
    [Header("Colocar aqui a soma do segundo e terceiro pedido")] // verde
    public Material pedido2e3Final;
    [Header("Colocar a soma anterior com o terceiro pedido")] // cyan
    public Material pedido3e3Final;

    public Material misturaErrada;



    void Start()
    {
        playerNaCaixa = false;
        player2NaCaixa = false;
        possoFazerAcao = false;
        tintaNaPia = gameObject.transform.GetChild(0);
        _corPia = corPia.GetComponent<Renderer>().material;
        tintaNaPia.gameObject.SetActive(false);
        numeroItens = 0;
    }


    GameObject _objetoFinal;
    public void CriarPedido()
    {
        if (idObjeto1 == 1 && idObjeto2 == 1) //vermelho
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto red";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 1;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido1Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido1Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if (idObjeto1 == 2 && idObjeto2 == 2) //amarelo
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto yellow";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 2;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido2Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido2Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if (idObjeto1 == 3 && idObjeto2 == 3) //azul
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto blue";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 3;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido3Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido3Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if (idObjeto1 == 1 && idObjeto2 == 2 || idObjeto1 == 2 && idObjeto2 == 1) //laranja
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto orange";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 4;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido1e2Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido1e2Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if ((idObjeto1 == 1 && idObjeto2 == 3) || (idObjeto1 == 3 && idObjeto2 == 1)) //roxo
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto violet";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 5;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido1e3Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido1e3Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if (idObjeto1 == 2 && idObjeto2 == 3 || idObjeto1 == 3 && idObjeto2 == 2) //verde
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto green";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 6;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido2e3Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido2e3Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else if (idObjeto1 == 6 && idObjeto2 == 3 || idObjeto1 == 3 && idObjeto2 == 6) //ciano
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "P1 ProdutoPronto cyan";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 7;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = pedido3e3Final;
            objetoFinalChild2.GetComponent<Renderer>().material = pedido3e3Final;
            NullEverything();
            objetoFinalChild = null;
        }
        else
        {
            _objetoFinal = (GameObject)Instantiate(objetoFinal, new Vector3(spawnplace.transform.position.x, spawnplace.transform.position.y, spawnplace.transform.position.z), objetoFinal.transform.rotation);
            _objetoFinal.gameObject.name = "Lixo";
            _objetoFinal.gameObject.tag = "ItemRequisito";
            _objetoFinal.GetComponent<Pedido1>().idPedido = 10;
            Transform objetoFinalChild = _objetoFinal.transform.GetChild(1);
            Transform objetoFinalChild2 = _objetoFinal.transform.GetChild(2);
            objetoFinalChild.GetComponent<Renderer>().material = misturaErrada;
            objetoFinalChild2.GetComponent<Renderer>().material = misturaErrada;
            NullEverything();
            objetoFinalChild = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerNaCaixa = true;
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            player2NaCaixa = true;
        }
        if ((other.gameObject.CompareTag("Ingrediente") && numeroItens == 0) || (other.gameObject.CompareTag("ItemRequisito") && numeroItens == 0))
        {
            idObjeto1 = other.gameObject.GetComponent<Pedido1>().idPedido;
            objetoColocado1 = other.transform;
            Destroy(other.gameObject);
            Renderer _objetoColocado1 = objetoColocado1.GetComponent<Renderer>();
            Renderer meshObjeto1 = objetoColocado1.transform.GetChild(1).GetComponent<Renderer>();
            _corPia.color = meshObjeto1.material.color;
            numeroItens = 1;
            tintaNaPia.gameObject.SetActive(true);
            objetoColocado1BOLHA.GetComponent<Renderer>().material.color = meshObjeto1.material.color;
            objetoColocado1BOLHA.gameObject.SetActive(true);
            objetoColocado1 = null;
            _objetoColocado1 = null;
            meshObjeto1 = null;
            other = null;
        }
        else if ((other.gameObject.CompareTag("Ingrediente") && numeroItens == 1) || (other.gameObject.CompareTag("ItemRequisito") && numeroItens == 1))
        {
            idObjeto2 = other.gameObject.GetComponent<Pedido1>().idPedido;
            objetoColocado2 = other.transform;
            Renderer _objetoColocado2 = objetoColocado2.GetComponent<Renderer>();
            Destroy(other.gameObject);
            Renderer meshObjeto2 = objetoColocado2.transform.GetChild(1).GetComponent<Renderer>();
            _corPia.color = meshObjeto2.material.color;
            numeroItens = 2;
            tintaNaPia.gameObject.SetActive(true);
            objetoColocado2BOLHA.GetComponent<Renderer>().material.color = meshObjeto2.material.color;
            objetoColocado2BOLHA.gameObject.SetActive(true);
            objetoColocado2 = null;
            _objetoColocado2 = null;
            meshObjeto2 = null;
            possoFazerAcao = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerNaCaixa = false;
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            player2NaCaixa = false;
        }
    }

    void NullEverything()
    {
        objetoColocado1BOLHA.gameObject.SetActive(false);
        objetoColocado2BOLHA.gameObject.SetActive(false);
        tintaNaPia.gameObject.SetActive(false);
        idObjeto1 = 0;
        idObjeto2 = 0;
        possoFazerAcao = false;
        numeroItens = 0;
    }
}
