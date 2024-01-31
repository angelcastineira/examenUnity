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

    // Start is called before the first frame update
    void Start()
    {
        // esto settea el valor de la variable "rb" a el valor del componente de 
        // Rigidbody que esta adjunto a la pelota (GameObject player)
        rb = GetComponent<Rigidbody>();
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
}
