using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PArentActive : MonoBehaviour
{

    public Image parentImage;
    private Image thisImage;

    private void Start()
    {
        thisImage = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (parentImage.enabled == true)
        {
            thisImage.enabled = true;
        }
        else
        {
            thisImage.enabled = false;
        }
    }

}
