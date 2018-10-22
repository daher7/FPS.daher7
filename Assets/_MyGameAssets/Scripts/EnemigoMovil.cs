using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : Enemigo {

    [Header("Enemigo Movil")]
    [SerializeField] protected int speed = 3;
    [SerializeField] protected int inicioRotacion = 1;
    [SerializeField] protected int tiempoEntreRotacion = 2;

    // 
    private void Start() {

        InvokeRepeating("RotarAleatoriamente", inicioRotacion, tiempoEntreRotacion);
    }

    // METODOS PROPIOS
    // EL enemigo rota
    protected void RotarAleatoriamente() {

        float rotation = Random.Range(0f, 180f);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }
    // El enemigo Avanza
    protected void Avanzar() {
        if (estaVivo) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    // El enemigo colisiona con el Personaje, explota y muere
    private void OnCollisionEnter(Collision collision) {
        RotarAleatoriamente();
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Personaje>().RecibirDanyo(danyo);
            Morir();
        }
    }
}
