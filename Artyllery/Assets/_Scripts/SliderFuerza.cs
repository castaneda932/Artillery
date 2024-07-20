using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.ShaderGraph;

public class SliderFuerza : MonoBehaviour
{

    public AdministradorJuego opciones;

    Slider slider;

    public float fuerza;

    private InputAction modificarFuerza;

    public void Awake()
    {
        modificarFuerza = new InputAction();
    }

    public void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ControlarVelocidad(); });
    }
    public void ControlarVelocidad()
    {
        opciones.cambiarVelocidadBola(slider.value);
        
    }

    public void Update()
    {
        fuerza += modificarFuerza.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;

        if (fuerza <= 100 && fuerza > -0) 
        {
            transform.eulerAngles = new Vector3(fuerza, 100, 0.0f);
        }
       
        if (fuerza > 100) fuerza = 100;
        if (fuerza < 0) fuerza = 0;
    }
}
