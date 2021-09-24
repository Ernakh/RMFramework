using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarParent : MonoBehaviour
{

    public GameObject parent;
    private MeshRenderer rend;
    private MeshRenderer thisRend;
    private Material childMat;
    private Material paiMat;
    private void Start()
    {
        rend = parent.GetComponent<MeshRenderer>();
        thisRend = gameObject.GetComponent<MeshRenderer>();
        childMat = this.gameObject.GetComponent<Renderer>().material;
        paiMat = rend.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (rend.enabled == false)
        {
            thisRend.enabled = false;
        }
        else
        {
            thisRend.enabled = true;
            childMat = paiMat;
        }
    }

}
