using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEstatico : Enemigo {

    // Declaracion de variables
    float tiempoAtaque;
    [SerializeField] float distanciaAtaque = 10f;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform posGeneracionProyectil;
    [SerializeField] int potenciaDisparo = 700;
    [SerializeField] float tiempoEntreDisparos = 3f;

    private void Start() {
        tiempoAtaque = tiempoEntreDisparos;
    }

    void Update() {

        // Medimos la distancia que hay entre la torreta y el jugador con un vector
        // Para que no cabecee, el eje X es la altura de la torreta
        Vector3 target = new Vector3(
            personaje.transform.position.x,
            transform.position.y,
            personaje.transform.position.z);

        // Miramos al personaje
        transform.LookAt(target);
        // Obtenemos el vector distancia
        Vector3 distancia = GetDistancia();
        // Evaluamos si la distancia entre los dos es menor que la distancia de ataque
        if(distancia.sqrMagnitude < (distanciaAtaque * distanciaAtaque))
        {
            IntentoDeAtaque();
        }
    }

    // METODOS PROPIOS
    private void IntentoDeAtaque()
    {
        tiempoAtaque += Time.deltaTime;
        if(tiempoAtaque >= tiempoEntreDisparos)
        {
            tiempoAtaque = 0;
            // Genera disparo, ataca, lanza
            Disparar();
        }
    }
    // El enemigo dispara
    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil,
            posGeneracionProyectil.position,
            posGeneracionProyectil.rotation);
        // Le aplicamos una fuerza y lo disparamos
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * potenciaDisparo);
    }
}
