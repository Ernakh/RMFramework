using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerador : MonoBehaviour
{
    private Collider ObjetoCL;

    private void Start()
    {
        ObjetoCL = this.GetComponent<Collider>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Ingrediente") || collision.gameObject.CompareTag("Prato") || collision.gameObject.CompareTag("ItemRequisito"))
        {
            collision.gameObject.transform.parent = null;
            Destroy(collision.gameObject);
        }
    }
}
