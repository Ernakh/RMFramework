using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegador : MonoBehaviour
{
    private Transform destino;
    public static bool PodePegar1 = true;
    private Rigidbody ObjetoRB;
    private Collider ObjetoCL;
    private Transform Objeto;
    private bool temObjetoPegavel = false;
    public static bool podeFazerAcao = false;

    List<string> listaObjtsValidos = new List<string>() {"ItemRequisito", "Ingrediente"};

    private void Start()
    {
        destino = gameObject.transform;
        PodePegar1 = true;
        podeFazerAcao = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PodePegar1 && temObjetoPegavel)
        {
            StartCoroutine(TakeItem());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !PodePegar1 && temObjetoPegavel)
        {
            StartCoroutine(DropItem());
        }
    }

    IEnumerator TakeItem()
    {
        Objeto.transform.parent = this.transform; //virou child
        Objeto.transform.position = destino.transform.position;
        ObjetoCL.enabled = false;
        yield return new WaitForSeconds(0.01f);
        Vector3 originalScale = Objeto.transform.localScale;
        originalScale = Objeto.transform.localScale;
        PodePegar1 = false;
        ObjetoRB.constraints = RigidbodyConstraints.FreezeAll; //congelou as rotações. eu descongelo diretamente no objeto pegado, no lateupdate
        yield return null;
    }
    IEnumerator DropItem()
    {
        Objeto.GetComponent<Rigidbody>().useGravity = true;
        Objeto.transform.parent = null; //tirou parent
        ObjetoCL.enabled = true;
        yield return new WaitForSeconds(0.01f);
        ObjetoCL.enabled = true;
        ObjetoRB.constraints = RigidbodyConstraints.None; //congelou as rotações. eu descongelo diretamente no objeto pegado, no lateupdate
        nullTransform();
        PodePegar1 = true;
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (listaObjtsValidos.Contains(other.gameObject.tag))
        {
            temObjetoPegavel = true;
            Objeto = other.GetComponent<Transform>();
            ObjetoRB = other.GetComponent<Rigidbody>(); //declarando pra usar em outras funções
            ObjetoCL = other.GetComponent<Collider>();
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
        PodePegar1 = true;
        Objeto = null;
        ObjetoRB = null;
        ObjetoCL = null;
    }
}