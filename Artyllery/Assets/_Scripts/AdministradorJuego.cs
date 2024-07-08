using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{

    public static AdministradorJuego SingletonAdministardorJuego;
    public static int VelocidadBola = 60;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = .5f;

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
}
