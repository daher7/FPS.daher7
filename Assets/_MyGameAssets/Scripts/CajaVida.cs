using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaVida : Caja {

    // Vida que le damos al jugador por cada caja de vida que recoge
    [SerializeField] int vida = 5;
   
    private void OnTriggerEnter(Collider other) {

        // Le damos vida al personaje al colisionar con el 
         if (other.gameObject.CompareTag("Player")) {
            Personaje p = other.gameObject.GetComponent<Personaje>();
            p.IncrementarVida(vida);

            // Llamamos al Sistema de Particulas
            ParticleSystem ps = Instantiate(
                psCaja,
                transform.position,
                Quaternion.identity);
           // this.GetComponent<AudioSource>().Play();
            ps.Play();

            // Cuando recogemos el botiquin, este desaparece
            Destroy(this.gameObject);
         }
       
    }
}
