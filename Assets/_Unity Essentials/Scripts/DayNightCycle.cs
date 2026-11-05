using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Durata totale di un intero giorno in secondi reali.")]
    public float dayDurationInSeconds = 120f; // Default: 2 minuti per un giorno completo

    void Update()
    {
        // Un giro completo equivale a 360 gradi.
        // Calcoliamo quanti gradi ruotare ogni secondo.
        float rotationSpeed = 360f / dayDurationInSeconds;

        // Ruota la luce attorno all'asse X per simulare il movimento del sole
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
