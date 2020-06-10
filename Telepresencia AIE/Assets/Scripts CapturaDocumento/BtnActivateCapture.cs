using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnActivateCapture : MonoBehaviour
{
    public GameObject btnCapture;
    public GameObject planeCapture;

    public void ActivateBtnCapture()
    {
        Debug.Log("Entro 2");
        btnCapture.SetActive(true);
        planeCapture.SetActive(true);
        this.gameObject.SetActive(false);

        //btnCapture.GetComponent<Button>().enabled = true;
    }

}
