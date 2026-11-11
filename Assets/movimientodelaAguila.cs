using UnityEngine;

public class MovimientoAguila : MonoBehaviour
{
    // Esta es la velocidad a la que se moverá el águila. Puedes cambiarla desde el Inspector.
    public float velocidad = 5f;

    // Variable añadida para llevar la cuenta de los puntos
    private int puntos = 0;

    void Update()
    {
        // Obtiene las entradas del teclado de forma automática (W/D o Flechas)
        // 'horizontal' será -1 con la A, y 1 con la D
        float horizontal = Input.GetAxisRaw("Horizontal");

        // 'vertical' será -1 con la S, y 1 con la W
        float vertical = Input.GetAxisRaw("Vertical");

        // Creamos un vector de dirección con los movimientos
        Vector2 direccion = new Vector2(horizontal, vertical).normalized;

        // Movemos la posición de la águila multiplicando la dirección por la velocidad y el tiempo
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    // Función para detectar y desaparecer los objetos al tocarlos
    private void OnTriggerEnter2D(Collider2D objetoTocado)
    {
        // Si tocamos una gema (en minúsculas)
        if (objetoTocado.CompareTag("gem"))
        {
            puntos += 10; // Suma 10 puntos
            Debug.Log("Puntos: " + puntos);
            Destroy(objetoTocado.gameObject);
        }
        // Si tocamos una cereza (con la C mayúscula)
        else if (objetoTocado.CompareTag("Cereza"))
        {
            puntos -= 5; // Resta 5 puntos
            if (puntos < 0) puntos = 0; // Evita que los puntos sean negativos
            Debug.Log("Puntos: " + puntos);
            Destroy(objetoTocado.gameObject);
        }
    }
}