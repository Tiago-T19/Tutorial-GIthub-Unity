using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 28/08/26 Clase Programacion de Videojuegos PRACTICA
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensibility;

    void Update()
    {
        // Rotacion
        float x = Input.GetAxisRaw("Mouse X");
        player.Rotate(0f, x * sensibility, 0f, Space.Self);
        transform.LookAt(player);
    }

    private void LateUpdate()
    {
        // Seguimiento de la camara
        transform.position = player.position + player.rotation * offset;
    }
}
