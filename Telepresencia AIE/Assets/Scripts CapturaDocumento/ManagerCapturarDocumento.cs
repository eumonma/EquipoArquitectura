using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCapturarDocumento : MonoBehaviour
{
    public Button btnCaptura;

    private void Start()
    {
        Debug.Log("Comienzo");
    }

    void BtnEnableCaptureImage()
    {
        Debug.Log("Paso");
        btnCaptura.enabled = true;
    }
    
}
