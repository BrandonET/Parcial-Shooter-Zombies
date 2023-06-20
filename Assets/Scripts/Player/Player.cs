using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameType
{
    FirstPerson,
    ThirdPerson,
    SideScroller,
    TopView
}

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public GameType gameType;
    public GameObject followTransform;

    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public float rotationPower = 6f;
    public float rotationLerp = 0.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;

    private void Awake()
    {
        // Desaparece la imagen del cursor
        Cursor.lockState = CursorLockMode.Locked;

        // A�adir refrencia del CharacterController
        controller = GetComponent<CharacterController>();

        switch (gameType)
        {
            case GameType.SideScroller:
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                break;
        }
    }

    void Update()
    {
        // Verifica si el personaje est� en contacto con el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Si el personaje est� en el suelo y su velocidad en el eje Y es negativa, se establece en -2f para evitar que siga "cayendo"
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // El personaje seguira distintas instrucciones de movimiento dependiendo del tipo de juego
        switch (gameType)
        {
            case GameType.FirstPerson:
                FirstPersonMovement();
                break;
            case GameType.ThirdPerson:
                ThirdPersonMovement();
                break;
            case GameType.SideScroller:
                SideScrollerMovement();
                break;
            case GameType.TopView:
                TopViewMovement();
                break;
        }

        // Si el usuario presiona el bot�n de salto y el personaje est� en el suelo, se aplica una fuerza de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SceneManager.LoadScene("POO2"); 
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar f�sica de ca�da libre al personaje
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void FirstPersonMovement()
    {
        // Obtiene la entrada del usuario para moverse en los ejes X y Z
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Calcula la direcci�n de movimiento y mueve al personaje
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void ThirdPersonMovement()
    {
        // Obtiene la entrada del usuario para moverse en los ejes X y Z
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Rota la c�mara al rededor del personaje
        followTransform.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationPower, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationPower, Vector3.right);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        // Bloquea la rotaci�n de arriba y abajo para que se vea m�s natural el movimiento
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTransform.transform.localEulerAngles = angles;

        // Calcula la direcci�n de movimiento y mueve al personaje
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void SideScrollerMovement()
    {
        // Obtiene la entrada del usuario para moverse en los ejes X y Z
        float x = 0;
        float z = Input.GetAxisRaw("Horizontal");

        // Calcula la direcci�n de movimiento y mueve al personaje
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void TopViewMovement()
    {
        // Obtiene la entrada del usuario para moverse en los ejes X y Z
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Calcula la direcci�n de movimiento y mueve al personaje
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
