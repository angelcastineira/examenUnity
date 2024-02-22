using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// este script va a hacer que el cubo se quede rotando mientras el juego esta activo
// recordar que previamente hemos rotado el cubo a 45 grados en el eje X, Y y Z
// para que el cubo rote los valores de esas coordenadas tienen que cambiar en cada frame
// hay 2 metodos para afectar la transformacion del GameObject: la translacion y la rotacion.
// ambos tienen 2 param posibles: Vector3 y usando los 3 valores de X,Y y Z (la mas sencilla es Vector3).
public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
        // hay que asegurarse que la "t" del "transform" es en minuscula ya que 
        // nos estamos refiriendo al COMPONENTE y NO a la VARIABLE
        // deltaTime es perfecto para asegurarse de que las acciones ocurren lentamente
        // pq deltaTime es un float que representa la diferencia en segundos desde el ultimo frame actualizado
        // por lo que esto va a cambiar dinamicamente el mov basado en la longitud del frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
