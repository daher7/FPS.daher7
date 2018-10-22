using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour {

    int numEnemigos = 0;
    [SerializeField] int numEnemigosMaximo = 10;
    [SerializeField] float ratioNuevoEnemigo = 4;
    [SerializeField] GameObject prefabEnemigo;


	// Use this for initialization
	void Start () {
        // Invocamos a los enemigos nada mas comenzar
        InvokeRepeating("GenerarEnemigo", 0, ratioNuevoEnemigo);
	}
	
    private void GenerarEnemigo()
    {
        GameObject nuevoEnemigo = Instantiate(
            prefabEnemigo,
            transform.position,
            Quaternion.identity);
        numEnemigos++;
        if(numEnemigos == numEnemigosMaximo)
        {
            CancelInvoke();
        }
    }
}
