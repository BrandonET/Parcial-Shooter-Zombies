using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force = 200f;
    public float currentTime;
    float lifeTime = 10f;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.AddForce(transform.forward * force);

    }


    private void Update()
    {

        currentTime = +-Time.deltaTime;

        if (currentTime >= lifeTime)

        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)

    {
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        currentTime = 0f;
    }
}
