using UnityEngine;

public class CamaraSeguidora : MonoBehaviour
{
    // --- VARIABLES Y TIPOS DE DATOS ---

    [Header("Configuración de Seguimiento")]
    // Tipo de dato: Transform (guarda la posición, rotación y escala de un objeto)
    // Identificador: objetivo (hace referencia al jugador que vamos a seguir)
    public Transform objetivo;

    // Tipo de dato: float (número con decimales)
    // Identificador: velocidadSeguimiento (controla qué tan suave se mueve la cámara)
    public float velocidadSeguimiento = 5f;

    [Header("Desplazamiento (Offset)")]
    // Tipo de dato: Vector3 (guarda coordenadas X, Y, Z)
    // Identificador: desfasamiento (mantiene a la cámara a una distancia segura para que no se pegue al jugador)
    public Vector3 desfasamiento = new Vector3(0f, 0f, -10f);


    // --- MÉTODOS ---

    // Método estándar de Unity que se ejecuta después de que el jugador realiza su movimiento
    private void LateUpdate()
    {
        // Validación: Si no se ha asignado un objetivo en el inspector, el método no hace nada para evitar errores
        if (objetivo == null)
        {
            return;
        }

        // 1. Calcular la posición ideal a la que debe ir la cámara (Posición del jugador + la distancia Z)
        Vector3 posicionDeseada = objetivo.position + desfasamiento;

        // 2. Método Lerp (Interpolación lineal): Interpola suavemente entre la posición actual y la deseada
        Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, velocidadSeguimiento * Time.deltaTime);

        // 3. Asignar la nueva posición calculada a la cámara
        transform.position = posicionSuave;
    }
}