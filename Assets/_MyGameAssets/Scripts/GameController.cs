using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject boss;
    public static GameObject referenciaJugador;
    public static GameObject[] enemigosVivos;
    public static bool estaJugando;

	// Use this for initialization
	void Start () {
        referenciaJugador = GameObject.Find("Personaje");
        estaJugando = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Comprobamos que no hay enemigos
        ComprobarNumeroEnemigosVivos();
        if (enemigosVivos.Length == 0 && boss != null) {
            boss.SetActive(true);
        }
	}
    // Comprobar los enemigos que hay en pantalla
    private static void ComprobarNumeroEnemigosVivos() {
        enemigosVivos = GameObject.FindGameObjectsWithTag("Enemigo");
    }
}
