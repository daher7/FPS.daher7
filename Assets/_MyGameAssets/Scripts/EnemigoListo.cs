using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoMovil {

	// Update is called once per frame
	void Update () {
        // Para que no cabecee
        Vector3 target = new Vector3(
            personaje.transform.position.x,
            transform.position.y,
            personaje.transform.position.z
            );

        Vector3 vDistancia = GetDistancia();
        if (vDistancia.magnitude <= 20)
        {
            this.transform.LookAt(target);
        }
        Avanzar(); 
	}
}
