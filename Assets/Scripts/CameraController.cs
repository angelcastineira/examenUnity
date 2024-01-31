using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // posicion del "player" tipo GameObject 
    public GameObject player;
    // va a ser privada pq solo quiero modificar esta var en el script
    // distancia entre la camara y el player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // esto tiene que suceder en cada frame por lo que tenemos que añadirlo en Update
        // calcula el "offset" inicial entre la posicion de la camara y la posicion del jugador.
        offset = transform.position - player.transform.position;
        
    }

    // -- PRIMERA SOLUCION (AUNQUE INCORRECTA) --
    // aunque lo pongamos aqui, no es la mejor posicion debido a que:
    // la posicion de la camara se realiza antes de que se ejecute el frame
    // esta transformacion podria ejecutarse antes de que se ejecute cualquier script
    // el mejor sitio dd poner el codigo es en el "Late Update" ya que aunque corre cada frame
    // (como el Update), va ser ejecutado despues de que se hayan ejecutado todas las otras actualizaciones
    /**
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
    **/

    // -- SEGUNDA SOLUCION (CORRECTA) --
    // ahora la posicion de la camara NO se va a mover ANTES de que el "player" se ha movido debido a ese frame 
    // LateUpdate is called once per frame after all Upadte functions have been completed
    void LateUpdate()
    {
        // mantiene el mismo "offset" entre la camara y el jugador en todo el juego
        transform.position = player.transform.position + offset;
    }
}
