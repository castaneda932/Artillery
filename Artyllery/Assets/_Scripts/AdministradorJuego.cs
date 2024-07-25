using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorJuego : MonoBehaviour
{

    public static AdministradorJuego SingletonAdministardorJuego;
    public static float VelocidadBola;
    public static int DisparosPorJuego = 3;
    public static float VelocidadRotacion = .5f;

    public GameObject canvasGanar;
    public GameObject canvasPerder;
    public GameObject menuCanvasGameOver;
    

    private void Awake()
    {
        if (SingletonAdministardorJuego == null)
        {
            SingletonAdministardorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }

    private void Update()
    {
        if (DisparosPorJuego <=0)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        canvasGanar.SetActive(true);
    }
    public void PerderJuego()
    {
        canvasPerder.SetActive(true);
        menuCanvasGameOver.SetActive(true);
    }
    public void ReintentarNivel()
    {
        canvasPerder.SetActive(false);
        menuCanvasGameOver.SetActive(false);

        DisparosPorJuego = 3;


    }
    public void cambiarVelocidadBola(float nuevaVelocidad)
    {
        VelocidadBola = nuevaVelocidad;
    }

    public void SiguienteNivel()
    {
        SceneManager.LoadScene(2);
    }
    
    
}
