using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// InputSystem namespace
// habilita que pueda acceder al codigo y las funciones
// el componente PlayerInput va a notificar al script del PlayerController
// de una accion que esta pasando. Esto lo notifica al llamar a las funciones
// predefinidas. Estas funciones predefinidas que indican el movimiento de la pelota
// se llama "onMove()"
// en esta funcion el juego leera el valor 
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // al ponerla publica, puedo acceder a ella desde el "Inspector" (desde el IDE de Unity)
    public float speed = 0;
    // variable a la cual el Rigidbody necesita tener acceso
    // es privada pq no necesitas que esta variable sea accesible por el "Inspector" o otrosattached scripts
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Spawner spawner; // Referencia al script Spawner

    // Start is called before the first frame update
    void Start()
    {
        // esto settea el valor de la variable "rb" a el valor del componente de 
        // Rigidbody que esta adjunto a la pelota (GameObject player)
        rb = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<Spawner>(); // Encuentra el objeto Spawner en la escena
    }

    // el PlayerInput va a estar enviando informacion
    // el movimiento de la pelota va a ser capturado en 2 direcciones: arriba y abajo, derecha e izq
    // es decir, el movimiento va a ser capturado por las direcciones X e Y 
    // este tipo de info puede ser guardado por una variable "Vector2"
    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // metodo para añadir fuerza
    void FixedUpdate() {
        //Soluciono el posible error (readme) agregando las 2 siguientes lineas
        //rb.addForce(movementVector);

        // f siginifica que es un valor de tipo float
        Vector3 movement = new Vector3(movementX, 0.0f, movementY );

        rb.AddForce(movement * speed);
        

    }

    //trigger = desencadenar/disparador // behavior = comportamiento
    // para hacer que las monedas desaparezcan con la colision de la bola
    // para lograr esto necesito que se detecte la colision del GameObject Player con el del GameObject Pickup
    // cd detecte esta colision, tengo que desencadernar un comportamiento
    // la funcion OnTriggerEnter va a detectar la colision entre esos 2 obj
    // la funcion va a ser llamada por Unity cada vez que el Player GameObject toca por primera vez un "colisionador de disparador"
    // y esto le va a dar una referencia al "colisionador de disparador" de que ha sido tocado. Este "colisionador de disparador" se llama
    // "other". esta es un ref de los objetos "Collider" que fueron tocados
    private void OnTriggerEnter(Collider other) {
        // el if es para comprobar que el GameObject tocado (identificado por "other") es el que queremos desactivar 
        if(other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Enemy")) {
            // Invoca la función SpawnEnemy del script Spawner
            spawner.SpawnEnemy();
        }
    }
}
