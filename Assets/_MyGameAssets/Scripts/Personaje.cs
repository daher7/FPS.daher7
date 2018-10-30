using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour {
    // DEclaración de Variables:
    private const int NUM_ARMAS = 2;
    private int armaActiva = 0;
    bool estaVivo;

    [Header("ESTADO")]
    [SerializeField] int vidaActual = 150;
    [SerializeField] int vidaMaxima = 150;
    [SerializeField] Image barraDeVida;
    

    [Header("ARSENAL")]
    [SerializeField] Arma[] armas = new Arma[NUM_ARMAS];
    [SerializeField] float tiempoEntreDisparos = 0.05f;
    float tiempoAtaque;
    
	void Start () {
        // Activamos el arma
        ActivarArma(armaActiva);
	}
	
	void Update () {

        // Progreso de la Barra de Vida
        barraDeVida.fillAmount = vidaActual;
        // Disparar el arma
        if (Input.GetMouseButtonDown(0)) {
            intentoDeAtaque();
        }

        // Seleccion del Arma
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            armaActiva = 0;
            ActivarArma(armaActiva);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            armaActiva = 1;
            ActivarArma(armaActiva);
        }
	}

    // METODOS PROPIOS DEL PERSONAJE
    // Activacion del Arma
    public void ActivarArma(int armaActiva) {

        DesactivarArmas();
        armas[armaActiva].gameObject.SetActive(true);
        
    }
    // Desactivacion de las armas que no se están usando
    public void DesactivarArmas() {

        foreach(var arma in armas) {
            arma.gameObject.SetActive(false);
        }
    }
    // 
    private void intentoDeAtaque()
    {
        tiempoAtaque += Time.deltaTime;
        if(tiempoAtaque >= tiempoEntreDisparos)
        {
            tiempoAtaque = 0;
            Disparar();
        }
    }

    // Disparar el arma
    public void Disparar() {

        armas[armaActiva].ApretarGatillo();
    }
    // Morir
    public void Morir()
    {
        estaVivo = false;
        Destroy(this.gameObject);
    }

    // Recibir daño
    public void RecibirDanyo(int danio)
    {
        vidaActual -= danio;   

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }
    }
    // Incrementar vida al recibir salud
    public void IncrementarVida(int incrementoVida)
    {
        vidaActual += incrementoVida;
        // Evitamos superar la salud maxima
        if (vidaActual >= vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }
}
