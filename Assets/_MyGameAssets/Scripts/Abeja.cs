using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeja : MonoBehaviour {

    Vector3 prevPos;
    Vector3 currentPos;
    Vector3 difPos;
    bool primeraVez = true;

    private void Start()
    {
        //Invoke("Destruir", 3);
    }

    private void FixedUpdate()
    {
        /*
         * Calculamos el vector que lleva desde la posicion anterior a la actual.
         * 
         * Dicho vector representa el punto hacia donde debe mirar la flecha para 
         * que tenga comportamiento parabólico.
         */

        currentPos = transform.position;
        if (!primeraVez)
        {
            difPos = currentPos - prevPos;
            // La normalizacion de difPos no es necesaria.
            this.transform.forward = difPos.normalized;
        }
        else
        {
            primeraVez = false;
        }
        prevPos = currentPos;
    }


    private void OnCollisionEnter(Collision other)
    {
        // Para que la flecha se quede clavada en la pared
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        // Si es un enemigo, le inflingimos un daño
        GameObject objetivoImpacto = other.gameObject;
        if (objetivoImpacto.CompareTag("Enemigo"))
        {
            objetivoImpacto.GetComponent<Enemigo>().RecibirDanyo(1);
        }

        // Destruimos el SCRIPT para que no continue la rotacion
        Destroy(this);
    }

}
