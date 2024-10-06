using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    public float force = 50f;
    
        // Start is called before the first frame update
    
    public void OnCollisionEnter(Collision collision)
    {
        Vector3 inNormal = Vector3.Normalize(transform.position - collision.transform.position);
        Vector3 bounceVector = Vector3.Reflect(collision.relativeVelocity, inNormal);
        if (collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(bounceVector.x * force, 0f, bounceVector.z * force, ForceMode.VelocityChange);
        }
    }
    public void CollisionPoint(Collision collision)
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
