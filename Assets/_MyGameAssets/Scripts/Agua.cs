using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour {

	private void OnTriggerStay(Collider other)
    {
        GameObject objetivoAgua = other.gameObject;
        if (objetivoAgua.CompareTag("Player"))
        {
            objetivoAgua.GetComponent<Personaje>().RecibirDanyo(1);
        }
    }
   
}
