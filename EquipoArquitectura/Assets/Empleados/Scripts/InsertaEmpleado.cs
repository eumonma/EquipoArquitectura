using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class InsertaEmpleado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var url = "empleadosmantenimiento.azurewebsites.net/api/AltaEmpleado?code=GUiNjOkmi2j7VSp3brmCe306gFv4oYxl0wSBpWJQzPV6tW6GoGHMyA==";
        var jsonAEnviar = "";

    StartCoroutine(CallPost(url, "JSON"));
    }

    
    public IEnumerator CallPost(string url, string logindataJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(logindataJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
        }

    }

   
}
