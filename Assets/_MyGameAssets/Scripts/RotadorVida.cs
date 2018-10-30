using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadorVida : MonoBehaviour {

    Camera mainCamera;

	void Start () {
        mainCamera = Camera.main;
        transform.rotation = mainCamera.transform.rotation;
	}
	
	void Update () {
        transform.rotation = mainCamera.transform.rotation;
    }
}
