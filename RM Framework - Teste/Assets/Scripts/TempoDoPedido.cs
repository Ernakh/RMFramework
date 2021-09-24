using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoDoPedido : MonoBehaviour
{
    public float tempoPedido;
    public bool podeTrocar = false;
    public Image Fill;

    public Texture pedido1RED;
    public Texture pedido1YELLOW;
    public Texture pedido1ORANGE;
    public Texture pedido1BLUE;
    public Texture pedido1VIOLET;
    public Texture pedido1GREEN;

    public RawImage ingrediente1;
    public RawImage ingrediente2;
  //  public Image somente1Ingrediente; //este eh para pedidos solitarios

    private void Start()
    {
        Fill.gameObject.GetComponent<RawImage>();
        ingrediente1.gameObject.GetComponent<RawImage>();
        ingrediente2.gameObject.GetComponent<RawImage>();
    }
    // Update is called once per frame
    void Update()
    {
        if (podeTrocar)
        {
            StartCoroutine(TempoDessePedido());
            Fill.fillAmount -= 1.0f / tempoPedido * Time.deltaTime;
            if (Fill.fillAmount == 0)
            {
                Fill.fillAmount = 1;
                gameObject.SetActive(false);
                GameManager.pedidosCheio = false;
                GameManager.Pontos -= 20;
            }
        }

        if (this.gameObject.name == "P1 ProdutoPronto red")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1RED;
            ingrediente2.GetComponent<RawImage>().texture = pedido1RED;
       //     somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto yellow")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1YELLOW;
            ingrediente2.GetComponent<RawImage>().texture = pedido1YELLOW;
      //      somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto orange")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1RED;
            ingrediente2.GetComponent<RawImage>().texture = pedido1YELLOW;
      //      somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto blue")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1BLUE;
            ingrediente2.GetComponent<RawImage>().texture = pedido1BLUE;
          //  somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto violet")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1RED;
            ingrediente2.GetComponent<RawImage>().texture = pedido1BLUE;
          //  somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto green")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1YELLOW;
            ingrediente2.GetComponent<RawImage>().texture = pedido1BLUE;
         //   somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
        else if (this.gameObject.name == "P1 ProdutoPronto cyan")
        {
            ingrediente1.GetComponent<RawImage>().texture = pedido1BLUE;
            ingrediente2.GetComponent<RawImage>().texture = pedido1GREEN;
         //   somente1Ingrediente.GetComponent<RawImage>().texture = ;
        }
    }

    IEnumerator TempoDessePedido()
    {
        yield return new WaitForSeconds(tempoPedido);
        podeTrocar = false;
    }
}
