using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegador2 : MonoBehaviour
{
    public Transform destino;
    public static bool PodePegar2 = true;
    private Rigidbody ObjetoRB;
    private Collider ObjetoCL;
    private Transform Objeto;
    private bool temObjetoPegavel = false;
    public static bool podeFazerAcao2 = false;

    List<string> listaObjtsValidos = new List<string>() { "ItemRequisito", "Ingrediente" };

    private void Start()
    {
        PodePegar2 = true;
        podeFazerAcao2 = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pegar") && PodePegar2 && temObjetoPegavel)
        {
            StartCoroutine(TakeItem());
        }
        else if (Input.GetButtonDown("Pegar") && !PodePegar2 && temObjetoPegavel)
        {
            StartCoroutine(DropItem());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (listaObjtsValidos.Contains(other.gameObject.tag))
        {
            temObjetoPegavel = true;
            Objeto = other.GetComponent<Transform>();
            ObjetoRB = other.GetComponent<Rigidbody>(); //declarando pra usar em outras funções
            ObjetoCL = other.GetComponent<Collider>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (listaObjtsValidos.Contains(other.gameObject.tag))
        {
            temObjetoPegavel = false;
            nullTransform();
            other = null;
        }
    }

    void nullTransform()
    {
        Objeto = null;
        ObjetoRB = null;
        ObjetoCL = null;
    }



    IEnumerator TakeItem()
    {
        Objeto.transform.parent = this.transform; //virou child
        Objeto.transform.position = destino.transform.position;
        yield return new WaitForSeconds(0.01f);
        Vector3 originalScale = Objeto.transform.localScale;
        originalScale = Objeto.transform.localScale;
        PodePegar2 = false;
        ObjetoRB.constraints = RigidbodyConstraints.FreezeAll; //congelou as rotações. eu descongelo diretamente no objeto pegado, no lateupdate
        yield return null;
    }

    IEnumerator DropItem()
    {
        Objeto.transform.parent = null; //tirou parent
        yield return new WaitForSeconds(0.01f);
        Objeto.GetComponent<Rigidbody>().useGravity = true;
        nullTransform();
        PodePegar2 = true;
        yield return null;
    }
}