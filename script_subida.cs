
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_subida : MonoBehaviour
{
    public float propulsion = 150.0f;
  
     void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es el jugador

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("subida");
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                Debug.Log("prueba");
                playerRigidbody.AddForce(Vector3.up * Time.deltaTime *5 * propulsion, ForceMode.Impulse);
            }
        }
    }
}

