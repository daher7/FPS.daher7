using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaBalas : Caja {

    // Municion que le damos al jugador al pasar sobre la caja
    [SerializeField] int municion = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Arma arma = other.gameObject.GetComponentInChildren<Arma>();
            arma.IncrementarMunicion(municion);

            // Llamamos al Sistema de Particulas
            ParticleSystem ps = Instantiate(
                psCaja,
                transform.position,
                Quaternion.identity);
            ps.Play();

            // Cuando recogemos el botiquin, este desaparece
            Destroy(this.gameObject);
        }
    }

}
