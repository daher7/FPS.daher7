using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {

    public Transform ejeRotacion;
	// Use this for initialization
	void Start () {
		// AbrirPuerta();
        // StartCoroutine(OpenDoor());
	}
	
    // Función Normal
	public void AbrirPuerta() {

        for(int i = 0; i < 128; i++) {
            ejeRotacion.Rotate(new Vector3(0, 1, 0));
        }
    }

    // Corrutina
    public IEnumerator OpenDoor() {

        for (int i = 0; i < 128; i++) {
            ejeRotacion.Rotate(new Vector3(0, 1, 0));
            yield return null;
        }
    }
}
