using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour {

    [SerializeField] int rotacionX = 0;
    [SerializeField] int rotacionY = 5;
    [SerializeField] int rotacionZ = 0; 
    [SerializeField] protected ParticleSystem psCaja;
    bool subiendo = true;
    int deltaY = 0;

    public void Update()
    {
        // El objeto rota sobre sus ejes a una determinada velocidad
        transform.Rotate(new Vector3(rotacionX, rotacionY, rotacionZ));

        // La caja sube y baja a una determinada velocidad
        if (subiendo)
        {
            deltaY++;
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else
        {
            deltaY--;
            transform.Translate(Vector3.up * Time.deltaTime * -1);
        }

        if (deltaY > 20)
        {
            subiendo = false;
        }
        else if (deltaY <= 0)
        {
            subiendo = true;
        }
    }
}
