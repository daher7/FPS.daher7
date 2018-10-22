using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    // Destruimos el proyectil pasados 5 segundos
    void Start () {

        Invoke("Destruir", 3);
	}
	
	// Funcion de destruccion de la bala
    private void Destruir() {

        Destroy(this.gameObject);
    }

    // Se ejecuta cada vez que el proyectil colisiona con un objeto
    private void OnTriggerEnter(Collider other) {
        print("ONTRIGGER:" + other.name);
        GameObject objetivoBala = other.gameObject;
    
        // Vemos si el proyectil impacta con un enemigo 
        if(objetivoBala.tag == "Enemigo") {
            objetivoBala.GetComponent<Enemigo>().RecibirDanyo(1);
        }
        else if(objetivoBala.tag == "Player") {
            objetivoBala.GetComponent<Personaje>().RecibirDanyo(10);
        }
        // Destruimos la bala
        Destruir();
    }
}
