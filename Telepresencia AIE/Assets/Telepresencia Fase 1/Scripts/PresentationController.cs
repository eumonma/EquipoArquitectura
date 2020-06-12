using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.UIElements;
using UnityEngine;

public class PresentationController : MonoBehaviour
{
    public GameObject slide1;
    public GameObject slide2;
    public GameObject CanvasSlides;

    //public GameObject Trans2a3;
    public CPC_CameraPath pathTrans2a3;
    public CPC_CameraPath pathTrans3a2;

    public int momentoPresentacion = 0;
    private bool spacePress;
    private bool arrowLeftPress;
    private bool arrowRighPress;
    private bool arrowDownPress;
    private bool arrowUppPress;


    // Ubicaciones cámara según Paso:
    //
    // PASO 1 y 2:
    //   Position: 525, 171, -247
    //   Rotation: 0, 0, 0
    //
    // PASO 3:
    //   Position: 208.2773, -221.6655, 125.2161
    //   Rotation: 41.769, -45.653, 0




    // Start is called before the first frame update
    void Start()
    {
        //Obtenermos referencias
        // Path de Paso2 a Paso3

        EstadoInicial();
        PrepararPaso1();
        IniciarPaso1();
    }

    // Update is called once per frame
    void Update()
    {
        spacePress = Input.GetKeyDown(KeyCode.Space);
        arrowRighPress = Input.GetKeyDown(KeyCode.RightArrow);
        arrowDownPress = Input.GetKeyDown(KeyCode.DownArrow);
        arrowLeftPress = Input.GetKeyDown(KeyCode.LeftArrow);
        arrowUppPress = Input.GetKeyDown(KeyCode.UpArrow);

        if (spacePress || arrowRighPress || arrowDownPress)
        {
            PasoSiguiente();
        }
        else if (arrowLeftPress || arrowUppPress)
        {
            PasoAnterior();
        }

    }

    void PasoSiguiente()
    {
        print("Paso SIGUIENTE");

        switch (momentoPresentacion)
        {
            case 1:
                FinalizarPaso1();
                TransicionPasos1a2();
                PrepararPaso2();
                IniciarPaso2();
                break;
            case 2:
                FinalizarPaso2();
                TransicionPasos2a3(10);
                PrepararPaso3();
                IniciarPaso3();
                break;
        }
            
    }

    void PasoAnterior()
    {
        print("Paso ANTERIOR");

        switch (momentoPresentacion)
        {
            case 2:
                FinalizarPaso2();
                TransiciónPasos2a1();
                PrepararPaso1();
                IniciarPaso1();

                break;

            case 3:
//                FinalizarPaso3();

                StartCoroutine("Paso3a2", 10);
                //TransiciónPasos3a2(10);


//                PrepararPaso2();
//                IniciarPaso2();

                break;
        }

    }

    void EstadoInicial()
    {
        FinalizarPaso1();
        FinalizarPaso2();
        FinalizarPaso3();
    }

    void PrepararPaso1()
    {
        print("Preparar Paso 1...");

        momentoPresentacion = 1;
        slide1.SetActive(true);
        
    }

    void PrepararPaso2()
    {
        print("Preparar Paso 2...");

        momentoPresentacion = 2;

        CanvasSlides.SetActive(true);
        

    }

    void PrepararPaso3()
    {
        print("Preparar Paso 3...");

        momentoPresentacion = 3;
    }

    void IniciarPaso1()
    {

        print("Iniciar Paso 1...");

    }

    void IniciarPaso2()
    {

        print("Iniciar Paso 2...");
        slide2.SetActive(true);

    }

    void IniciarPaso3()
    {

        print("Iniciar Paso 2...");

    }

    void FinalizarPaso1()
    {
        print("Finalizar Paso 1...");
        slide1.SetActive(false);
    }

    void FinalizarPaso2()
    {
        print("Finalizar Paso 2...");
        slide2.SetActive(false);
    }

    void FinalizarPaso3()
    {
        print("Finalizar Paso 3...");

    }

    void TransicionPasos1a2()
    {
        print("Transición Paso 1 a 2 ...");

    }





    void TransicionPasos2a3(int tiempo)
    {
        print("Transición Paso 2 a 3 ...");
        CanvasSlides.SetActive(false);
        pathTrans2a3.PlayPath(tiempo);

    }

    void TransiciónPasos2a1()
    {
        print("Transición Paso 2 a 1 ...");

    }



    IEnumerator Paso3a2(int tiempo)
    {

        print("Transición Paso 3 a 2 ...");

        FinalizarPaso3();
        pathTrans3a2.PlayPath(tiempo);

        yield return new WaitUntil(() => !pathTrans3a2.IsPlaying());

        PrepararPaso2();
        IniciarPaso2();
       
    }


}
