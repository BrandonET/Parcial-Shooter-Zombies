using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 3f;

    private Rigidbody enemyRigidbody;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = (target.position - transform.position).normalized;
        // Mover el enemigo hacia el jugador
        enemyRigidbody.velocity = direction * enemySpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject); // Destruir el proyectil
            Destroy(gameObject); // Destruir el enemigo
        }
    }
}






