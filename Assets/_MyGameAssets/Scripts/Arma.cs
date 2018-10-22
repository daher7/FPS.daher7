using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    bool activa;
    
    [SerializeField] int numBalas = 75;
    [SerializeField] int numBalasMax = 75;
    [SerializeField] int potenciaDisparo;
    [SerializeField] TextMesh textoArma;

    // Desde el editor los seleccionamos
    [SerializeField] GameObject prefabBala;
    [SerializeField] GameObject puntoGeneracion;
    // Sonido de Disparo de las Armas
    [SerializeField] AudioClip sonidoArma;
    AudioSource fuenteAudio;

    private void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        // Mostramos el armamento actual
        textoArma.text = " " + numBalas;
    }
    // Disparamos el arma
    public void ApretarGatillo() {
        if(numBalas >= 1) {
            // Invocamos al prefab del proyectil
            GameObject nuevaBala = Instantiate(
                prefabBala,
                puntoGeneracion.transform.position,
                puntoGeneracion.transform.rotation);

            // Lanzamos el proyectil
            nuevaBala.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * potenciaDisparo);
            // Reproducimos el sonido de disparar el arma
            fuenteAudio.clip = sonidoArma;
            fuenteAudio.Play();
            numBalas--;
        }
        
    }

    public void IncrementarMunicion(int incrementoMunicion) {

        numBalas += incrementoMunicion;
        if(numBalas >= numBalasMax) {
            numBalas = numBalasMax;
        }
    }
}
