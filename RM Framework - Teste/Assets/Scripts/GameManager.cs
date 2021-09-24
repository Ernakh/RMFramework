using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Interface de pedidos"), Tooltip("Colocar aqui os pedidos no canvas")]
    public GameObject[] objetoSolicitado;

    [Header("Tempo de partida e pontuação"), Tooltip("Colocar aqui o tempo de partida")]
    public float Tempo = 40;
    public static int Pontos = 0;
    public static bool pedidosCheio = false;

    public TMP_Text pontosText;
    public TMP_Text tempoText;

    [Header("Script de inicio de jogo."), Tooltip("Esta script dá a opção ao jogador de escolher entre um ou dois jogadores. Só é possível jogar após selecionar alguma opção")]
    public GameObject gameoverPanel;
    public GameObject startgamePanel;
    public GameObject UIPedidos;
    public GameObject player1;


    private void Start()
    {
        Time.timeScale = 0;
        pedidosCheio = false;
        for (int i = 0; i < objetoSolicitado.Length; i++)
        {
            objetoSolicitado[i].GetComponent<Image>();
            objetoSolicitado[i].gameObject.SetActive(false);
        }
        Pontos = 0;
        
        startgamePanel.gameObject.SetActive(true);
        gameoverPanel.gameObject.SetActive(false);
        UIPedidos.gameObject.SetActive(false);
    }

    public void umJogador()
    {
        startgamePanel.gameObject.SetActive(false);
        startGame();
    }

    public void startGame()
    {
        Time.timeScale = 1;
        UIPedidos.gameObject.SetActive(true);
        QualPedido();

    }

    void Update()
    {
        Tempo -= Time.deltaTime;
        pontosText.text = "" + Pontos;
        tempoText.text = "" + Tempo.ToString("F0");

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        if (Tempo <= 0)
        {
            gameoverPanel.gameObject.SetActive(true);
            Tempo = 0;
            Time.timeScale = 0;
        }

    }

    IEnumerator QueroAlgo()
    {
        int randomTime = Random.Range(6, 12);
        if (!pedidosCheio)
        {
            yield return new WaitForSeconds(randomTime);
            QualPedido();
        }
        else if (pedidosCheio)
        {
            yield return new WaitForSeconds(4);
            StartCoroutine(QueroAlgo());
        }
    }
#region pedidos
    [Header("Imagem dos pedidos que irá aparecer no canvas"), Tooltip("Colocar aqui as respectivas imagens/sprites dos pedidos")]
    public Texture IMGpedido1;
    RawImage _IMGpedido1;
    public Texture IMGpedido2;
    RawImage _IMGpedido2;
    public Texture IMGpedido3;
    RawImage _IMGpedido3;
    public Texture IMGpedido4;
    RawImage _IMGpedido4;
    public Texture IMGpedido5;
    RawImage _IMGpedido5;
    public Texture IMGpedido6;
    RawImage _IMGpedido6;
    public Texture IMGpedido7;
    RawImage _IMGpedido7;

    #endregion

    private void QualPedido()
    {
        for (int i = 0; i < objetoSolicitado.Length; i++)
        {
            if (!objetoSolicitado[i].gameObject.activeSelf)
            {
                int Cor = Random.Range(1, 8);
                if (Cor == 1) //vermelho
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto red";

                    _IMGpedido1 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido1.texture = IMGpedido1;
                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 2) // amarelo
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto yellow";

                    _IMGpedido2 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido2.texture = IMGpedido2;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 3) //azul
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto blue";

                    _IMGpedido3 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido3.texture = IMGpedido3;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 4) //laranja
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto orange";

                    _IMGpedido4 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido4.texture = IMGpedido4;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 5) //violeta
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto violet";

                    _IMGpedido5 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido5.texture = IMGpedido5;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 6) //green
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto green";

                    _IMGpedido6 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido6.texture = IMGpedido6;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                else if (Cor == 7) //cyan
                {
                    float tempoDoPedido = Random.Range(80, 150);
                    objetoSolicitado[i].gameObject.SetActive(true);
                    objetoSolicitado[i].gameObject.name = "P1 ProdutoPronto cyan";

                    _IMGpedido7 = objetoSolicitado[i].GetComponent<RawImage>();
                    _IMGpedido7.texture = IMGpedido7;

                    var tempoPedido = objetoSolicitado[i].gameObject.GetComponent<TempoDoPedido>();
                    tempoPedido.tempoPedido = tempoDoPedido;
                    tempoPedido.podeTrocar = true;
                }
                StartCoroutine(QueroAlgo());
                return;
            }
            else if (objetoSolicitado[i].gameObject.activeSelf)
            {
                i = +i;
            }
        }
        pedidosCheio = true;
        StartCoroutine(QueroAlgo());
    }

    public void Recomecar()
    {
        SceneManager.LoadScene(0);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
