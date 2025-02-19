
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class player : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 


public GameObject camara2;
public GameObject camara;
public GameObject camra3;

public GameObject NewLevel;

public int requiredPickups = 1; // Número de pick-ups necesarios
public GameObject wall; 
public GameObject wall2;
public GameObject muro1;
private Animator estados;
public string estadoActual;

public GameObject esqueletos;
public GameObject araña;

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;
 public int count;
 

 // Speed at which the player moves.
 public float speed = 7; 
 public float propulsion = 20f;
 public TextMeshProUGUI countText;


 // Start is called before the first frame update.
 void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        NewLevel.SetActive(false);
        estados = GetComponent<Animator>();
        estados.SetBool("primer_nivel",true);
        camara.SetActive(true);
        camara.SetActive(false);

    }
 
 private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
    Debug.Log("Colision");
       // Destroy the current object
    rb.AddForce(Vector3.up * Time.deltaTime *10 * propulsion, ForceMode.Impulse);
       
   }
}

 void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
        
    }

    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count == requiredPickups){
            UnlockWall();
       }
   }

void UnlockWall()
    {
        if (wall != null)
        {
            Destroy(wall);
            Destroy(wall2); // Destruye la pared o la desactiva con wall.SetActive(false);
            Debug.Log("¡Pared desbloqueada!");
        }
    }



void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject.CompareTag("PickUp")){
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
        }
        
        if(other.gameObject.CompareTag("Soltar")){
            Debug.Log("jkahgsdas");
            Destroy(muro1);
        }
        if(other.gameObject.CompareTag("PortalFuego")){
            estados.SetBool("nivel_dos",true);
            Debug.Log("Estado portal");
            camara.SetActive(true);
            camara2.SetActive(false);
            araña.SetActive(true);
            cambiarCamara();
        }
        if(other.gameObject.CompareTag("Cielo")){
            estados.SetBool("tercer_nivel",true);
            esqueletos.SetActive(true);
            cambiarCamara();
            camara.SetActive(false);
        camara2.SetActive(false);
        camra3.SetActive(true);
        }
        if(other.gameObject.CompareTag("respawn")){
            rb.transform.position = new Vector3(0.17f,0.575f,1.55f);
        }

   }

void cambiarCamara(){
    Debug.Log("Entra en Cambiar Camara");
    if(estadoActual == "Segundo Nivel"){
        Debug.Log("Entra en el if para cambiar la camara");
        camara.SetActive(true);
        camara2.SetActive(false);
        camra3.SetActive(false);
        camara.transform.position = new Vector3(-7.977f,-1.913f,8.585f);
    }
    if(estadoActual == "Tercer Nivel"){
        Debug.Log("Cambiar camara cielo");
        camara.SetActive(false);
        camara2.SetActive(false);
        camra3.SetActive(true);
    }
}

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
        if(camara.activeSelf){
            Quaternion cameraRotation = camara.transform.rotation; // esto obtiene la rotacíon de la cámara


            Vector3 cameraForward = cameraRotation * Vector3.forward; // esto calcula la dirección hacia adelante de la cámara


            Vector3 movementDirection = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized; // esto  Proyecta la dirección hacia adelante en el plano horizontal (ignora inclinaciones verticales)


            Vector3 movement = movementDirection * movementY; // Crea el vector de movimiento basado en el input y la dirección de la cámara


            Vector3 dir = Vector3.zero;
                dir.x = Input.acceleration.x;
                dir.z = Input.acceleration.y;
                if (dir.sqrMagnitude > 1)
                    dir.Normalize();

                dir *= Time.deltaTime;
                transform.Translate(dir * speed, Space.World);
        }

        if(camara2.activeSelf || camra3.activeSelf){
                Vector3 dir = Vector3.zero;
                dir.x = Input.acceleration.x;
                dir.z = Input.acceleration.y;
                if (dir.sqrMagnitude > 1)
                    dir.Normalize();

                dir *= Time.deltaTime;
                transform.Translate(dir * speed, Space.World);
        }
        

        if (Input.GetKeyDown(KeyCode.Space)) {
        }
        Debug.Log(estadoActual);
        AnimatorStateInfo stateinfo = estados.GetCurrentAnimatorStateInfo(0);

        estadoActual = stateinfo.IsName("Segundo Nivel")? "Segundo Nivel":
        stateinfo.IsName("Primer Nivel")? "Primer Nivel":
        stateinfo.IsName("Tercer Nivel")? "Tercer Nivel":
        "Otro estado";


    }


}
