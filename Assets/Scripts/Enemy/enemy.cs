using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
private void Update(){

}

    
    private void OnCollisionEnter(Collision collision)
   {
     if (collision.gameObject.tag == "enemy")
{
   Destroy(collision.gameObject);
}
   }

}
