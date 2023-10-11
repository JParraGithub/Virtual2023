using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float velocidad_caminar=6.0f;
    public float velocidad_correr=10.0f;
    public float cantidad_salto=20.0f;
    public float gravedad =70.0f;
    private Vector3 movimiento = Vector3.zero;
    public short vida = 20000;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded){
            movimiento= new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if(Input.GetKey(KeyCode.LeftShift)){
                movimiento = transform.TransformDirection(movimiento)* velocidad_correr;                 
            }
            else{
                movimiento = transform.TransformDirection(movimiento)* velocidad_caminar;                
            }
            if(Input.GetKey(KeyCode.Space)){
                movimiento.y = cantidad_salto;
            }            
        }

        movimiento.y -= gravedad * Time.deltaTime;
        characterController.Move(movimiento*Time.deltaTime);
    
    }
    /*void OnCollisionEnter(Collision collision){ Enter,Exit,Stay

    }*/

    void OnTriggerEnter(Collider collider){

        //vida = vida-1000;
        //vida--;
        if(collider.gameObject.tag=="Enemigo"){
            vida -=100;
        }
        if(collider.gameObject.tag=="Sanacion"){
            vida+=100;
        }
        if(collider.gameObject.tag=="Debil"){
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag=="PowerUp"){
            velocidad_caminar=60.0f;
        }
    }
}

