using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed; // Velocidad en la que se mueve el jugador
    [SerializeField] private float runSpeed;
    private Vector3 dir = Vector3.zero; // Direccion empieza en 0

    void Update()
    {
        // MOVIMIENTO
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0, v);

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 mover = dir.normalized * speed * Time.deltaTime;
        transform.Translate(mover, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // COLISION
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Choca");
            collision.gameObject.GetComponent<Renderer>().material.color = Color.black;
            StartCoroutine(Destruir(collision.gameObject));
        }
    }

    public IEnumerator Destruir(GameObject obstacle)
    {
        // CORRUTINA
        yield return new WaitForSeconds(2f);
        Destroy(obstacle);
    }
}
