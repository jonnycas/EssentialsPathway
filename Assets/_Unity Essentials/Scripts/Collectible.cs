using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject effectCollect;

    // Parametri per la fluttuazione
    [Header("Floating Effect")]
    //serialize field va a sovrascirvere quello che diceva inspector
    //prima erano public e tiene salvato vecchio valore
    [SerializeField] private float floatSpeed = 2.0f;       // Velocità dell'oscillazione su/giù
    [SerializeField] private float floatAmplitude = 0.01f;  // Quanto in alto e in basso si sposta l'oggetto
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Salva la posizione iniziale da cui far partire l'oscillazione
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);

        //transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // Calcolo del movimento fluttuante su e giù
        //math abs per non fare andare sotto il terreno
        float newY = startPos.y + Mathf.Abs(Mathf.Sin(Time.time * floatSpeed)) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY + 0.01f, startPos.z);
        //+0.01f per non far toccare mai a terra
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Destroy the collectible
            //in c# this è implicito --> this.gameObject

            Destroy(gameObject);

            //Instantiate the obj
            Instantiate(effectCollect, transform.position, transform.rotation);

        }
        

    }
}
