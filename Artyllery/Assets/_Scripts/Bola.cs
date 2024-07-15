using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Rendering;

public class Bola : MonoBehaviour
{

    public GameObject particulasExplosionn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Invoke("Explotar", 3);
        }

        if (collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Obstaculo") Explotar();


    }


    public void Explotar()
    {
        GameObject particulas = Instantiate(particulasExplosionn, transform.position, Quaternion.identity) as GameObject;
        Cañon.Bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);

    }
}
