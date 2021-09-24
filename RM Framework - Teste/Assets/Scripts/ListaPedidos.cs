using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaPedidos : MonoBehaviour
{
    public Pedido pedido;
    public Image imageParent;

    private void Start()
    {
        imageParent.GetComponent<Image>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Local de Entrga")
        {
            pedido = null;
        }
    }

    private void Update()
    {

        if (gameObject.name == "P1 ProdutoPronto cyan")
            {
                imageParent.GetComponent<Image>().color = new Color32(0, 255, 255, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto red")
            {
                imageParent.GetComponent<Image>().color = new Color32(255, 0, 0, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto yellow")
            {
                imageParent.GetComponent<Image>().color = new Color32(255, 255, 0, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto blue")
            {
                imageParent.GetComponent<Image>().color = new Color32(0, 0, 255, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto orange")
            {
                imageParent.GetComponent<Image>().color = new Color32(255, 165, 0, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto green")
            {
                imageParent.GetComponent<Image>().color = new Color32(0, 255, 0, 120);
            }
            if (gameObject.name == "P1 ProdutoPronto violet")
            {
                imageParent.GetComponent<Image>().color = new Color32(255, 0, 255, 120);
            }
        
    }
}
