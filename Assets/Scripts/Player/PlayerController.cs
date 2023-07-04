using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5f; // Tiempo de vida del proyectil en segundos

    private Rigidbody playerRigidbody;
    private Vector2 cameraRotation = Vector2.zero;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento de la cámara
        cameraRotation.x += Input.GetAxis("Mouse X");
        cameraRotation.y -= Input.GetAxis("Mouse Y");
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0f);

        // Disparo de proyectiles
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void FixedUpdate()
    {
        // Movimiento del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        playerRigidbody.velocity = movement * 5f;
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        Vector3 cameraForward = mainCamera.transform.forward;
        projectileRigidbody.velocity = cameraForward * projectileSpeed;

        // Destruir el proyectil después de cierto tiempo
        Destroy(projectile, projectileLifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡El jugador ha colisionado con un enemigo!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena
        }
    }
}