using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFuego : MonoBehaviour
{
  
     void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es el jugador

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("portal");
            Transform transfor = collision.gameObject.GetComponent<Transform>();
            transfor.position = new Vector3(-8.635f,1f,8.871f);
        }
    }
}

