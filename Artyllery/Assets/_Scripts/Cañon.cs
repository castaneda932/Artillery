using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public static bool Bloqueado;

    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    private float rotacion;
    public int disparosRealizados = 0;
    // Start is called before the first frame update
    void Start()
    {
        puntaCanon =  transform.Find("PuntaCanon").gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        if(rotacion <= 90 && rotacion >- 0) // si la rotacion esta entre 0 y 90 ya no se podra mover
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        //son bloqueos para que si se pasa de 90 grados la rotacion se regrese a 90 e igual en 0 grados
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;

       

        if (Input.GetKeyDown(KeyCode.Space) &&!Bloqueado)
        {
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);// se instancia la bala con en la posicion y rotacion de punta canon
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles; // se creo un vector de disparo
            direccionDisparo.y = 90 - direccionDisparo.x;
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBola;
            

            disparosRealizados++;
            Bloqueado = true;

        }
        else if (disparosRealizados >= AdministradorJuego.DisparosPorJuego)
        {
            
            Destroy(this);
        }

    }
}
