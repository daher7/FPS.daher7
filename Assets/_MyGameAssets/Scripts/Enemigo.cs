using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    // DEclaracion de variables
    [Header("ESTADO")]
    [SerializeField] protected bool estaVivo = true;
    [SerializeField] int vida = 5;
    [Header("ATAQUE")]
    [SerializeField] int distanciaDeteccion = 5;
    [SerializeField] protected int danyo = 2;
    [Header("REFERENCIAS")]
    protected GameObject personaje;
    [SerializeField] protected ParticleSystem psExplosion;

    // Obtencion de las referencias del Player nada mas comenzar el juego
    private void Awake()
    {
        personaje = GameObject.Find("Personaje");
    }

    // METODOS PROPIOS
    // Recibir Daño
    public void RecibirDanyo(int danyo)
    {
        vida -= danyo;
        if(vida <= 0)
        {
            vida = 0;
            Morir();
        }
    }
    // Muerte del Enemigo
    public void Morir()
    {
        // Consideramos que el enemigo esta muerto
        estaVivo = false;
        // Explosionamos al enemigo
        ParticleSystem ps = Instantiate(
            psExplosion,
            transform.position,
            Quaternion.identity);
        ps.Play();
        // Destruimos al enemigo
        Destroy(this.gameObject);
    }
   
    // Obtener la distancia entre el Player y el Enemigo
    protected Vector3 GetDistancia()
    {
        return personaje.transform.position - transform.position;
    }
}
