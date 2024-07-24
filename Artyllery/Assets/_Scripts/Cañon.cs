using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Cañon : MonoBehaviour
{
    public static bool Bloqueado;

    public AudioClip ClipDisparo;
    public GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    [SerializeField] private GameObject BalaPrefab;
    public GameObject particulasDisparo;
    private GameObject puntaCanon;
    private float rotacion;
    public int disparosRealizados = 0;

    public CanonControlls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    public Slider sliderFuerza;

    private void Awake()
    {
        canonControls = new CanonControlls();
        AdministradorJuego.VelocidadBola = 0.3f;
    }

    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificaFuerza;
        disparar = canonControls.Canon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();

        disparar.performed += Disparar;
        modificarFuerza.performed += ModificarFuerzaSlider;

    }


    // Start is called before the first frame update
    void Start()
    {
        puntaCanon =  transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
       
    }

    void ModificarFuerzaSlider(InputAction.CallbackContext context)
    {
        //dar valor a velocidadBola segun nuestro slider
        AdministradorJuego.VelocidadBola += context.ReadValue<float>();
        //limitar valores
        if (AdministradorJuego.VelocidadBola > 100) AdministradorJuego.VelocidadBola = 100;
        else if (AdministradorJuego.VelocidadBola < 0.3f) AdministradorJuego.VelocidadBola = 0.3f;
        //ajustar valor visual en slider
        sliderFuerza.value = AdministradorJuego.VelocidadBola;
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion > -0) // si la rotacion esta entre 0 y 90 ya no se podra mover
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        //son bloqueos para que si se pasa de 90 grados la rotacion se regrese a 90 e igual en 0 grados
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if (Bloqueado == false && AdministradorJuego.DisparosPorJuego > 0)
        { 
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);// se instancia la bala con en la posicion y rotacion de punta canon

            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles; // se creo un vector de disparo
            direccionDisparo.y = 90 - direccionDisparo.x;

             //VFX
            Vector3 direccionParticulas = new Vector3(90.0f + transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            GameObject Particulas = Instantiate(particulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas));


            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBola;

            AdministradorJuego.DisparosPorJuego--;

            SourceDisparo.Play();
 
            Bloqueado = true;

            
            
        }

        //if (disparosRealizados >= AdministradorJuego.DisparosPorJuego)
        //{

        //    Destroy(this);
        //}
    }
}
