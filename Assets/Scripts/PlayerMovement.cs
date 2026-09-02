using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed; // Velocidad para caminar
    [SerializeField] private float runSpeed; // Velocidad para correr
    private Vector3 dir = Vector3.zero; // Direccion empieza en 0

    void Update()
    {
        // MOVIMIENTO
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Direccion
        dir = new Vector3(h, 0, v);

        // Condicion ? si : no
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Mover
        Vector3 mover = dir.normalized * speed * Time.deltaTime;
        transform.Translate(mover, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // COLISION
        // Al colisionar
        if (collision.gameObject.CompareTag("Obstacle")) // Tag Obstacle
        {
            // Busca el renderer y cambia el color a negro
            collision.gameObject.GetComponent<Renderer>().material.color = Color.black;
            // Inicia una corrutina
            StartCoroutine(Destruir(collision.gameObject));
        }
    }

    // CORRUTINA --
    public IEnumerator Destruir(GameObject obstacle)
    {
        // Despues de 2s
        yield return new WaitForSeconds(2f);
        Destroy(obstacle); // Se destruye el obstaculo
    }
}
