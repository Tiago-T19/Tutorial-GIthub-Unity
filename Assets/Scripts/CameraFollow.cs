using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 28/08/26 Clase Programacion de Videojuegos PRACTICA
    [SerializeField] private Transform player; // Jugador
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensibility;

    void Update()
    {
       // ROTACION
        float x = Input.GetAxisRaw("Mouse X"); // Con el Mouse
        player.Rotate(0f, x * sensibility, 0f, Space.Self); // Rota en y
        transform.LookAt(player); // Sigue al jugador 
       
    }

    private void LateUpdate()
    {
        // Seguimiento de la CAMARA
        transform.position = player.position + player.rotation* offset;
    }
}
