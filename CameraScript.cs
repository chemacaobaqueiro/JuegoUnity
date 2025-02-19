using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        Cursor.visible = false;
    }


    void LateUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        if(movimientoHorizontal != 0)
        {
            transform.Rotate(0,movimientoHorizontal,0);
        }
        transform.position = player.transform.position + offset; 
    }
}
