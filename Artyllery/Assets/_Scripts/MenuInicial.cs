using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //atach a main camera y asignar a los botones
    public GameObject MenuOpciones;
    public GameObject MenuInicial;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void MostarMenuIncial()
    {
        MenuInicial.SetActive(true);
        MenuOpciones.SetActive(false);
    }

}
