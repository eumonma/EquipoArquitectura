using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDeviceSize : MonoBehaviour
{
    public Text textWitdth;
    public Text textHeight;

    public Text rutaImagen;

    // Start is called before the first frame update
    void Start()
    {
        float width = Screen.width;
        float height = Screen.height;

        print("Width: " + width);
        print("Heigth: " + height);

        textWitdth.text = width.ToString();
        textHeight.text = height.ToString();

        //        rutaImagen.text = Application.dataPath;
        rutaImagen.text = Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
