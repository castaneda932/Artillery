using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego singletonAdministradorJuego;
    public static int VelocidadBola = 30;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = 1;
    // Start is called before the first frame update
    public void Awake()
    {
        if (singletonAdministradorJuego == null)
        {
            singletonAdministradorJuego = this;

        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }
}
