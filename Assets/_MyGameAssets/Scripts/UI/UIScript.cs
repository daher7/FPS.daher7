using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Incorporamos la libreria necesaria (Gestor de Escenas)
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

	public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
