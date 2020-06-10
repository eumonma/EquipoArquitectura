using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreemShootHandler : MonoBehaviour
{

    private static ScreemShootHandler instance;
    private Camera myCamera;
    private bool takeScreenShotOnNextFrame;
    public GameObject btnGoogleCloud;


    public Text txtMensaje;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();

        

    }
    
   
    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            txtMensaje.text = "takeScreenShotOnNextFrame ON";
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            txtMensaje.text = "Before Encoding PNG";

            byte[] byteArray = renderResult.EncodeToPNG();
            //System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShoot.png", byteArray);
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/CameraScreenShoot.png", byteArray);

            txtMensaje.text = "Captura Realizada";
            Debug.Log("Captura Realizada");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;

            btnGoogleCloud.SetActive(true);
        }
    }

    private void TakeScreenShot(int width, int height)
    {
        Debug.Log("TakeScreenShot");
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }

    public static void TomaCaptura(int width, int height)
    {
        Debug.Log("TomaCaptura");
        instance.TakeScreenShot(width, height);
    }

    public void Prueba()
    {
        Debug.Log("Prueba");
        TomaCaptura(500, 500);
    }
}
