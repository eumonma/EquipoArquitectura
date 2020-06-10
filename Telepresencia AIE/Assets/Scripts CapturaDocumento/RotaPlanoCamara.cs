using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotaPlanoCamara : MonoBehaviour
{
    private bool finMovimiento = false;
    private int velocidad = 20;

    public GameObject planePadre;

   
    private void Awake()
    {
        planePadre.transform.Rotate(0, 0, -100);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("************");
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);
    }

    private void Update()
    {


        if (!finMovimiento)
        {
            planePadre.transform.Rotate(0, 0, Time.deltaTime * velocidad);

            if (planePadre.transform.rotation.z >= 0)
            {
                finMovimiento = true;
            }
        }
    }
}
