using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativarIMG : MonoBehaviour
{

    public GameObject child;
    private Image essaIMG;
    void Start()
    {
        essaIMG = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (child.gameObject.activeSelf)
        {
            essaIMG.enabled = true;
        }
        else essaIMG.enabled = false;
    }
}
