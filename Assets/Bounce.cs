using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = other.rigidbody.velocity.normalized;

            vel += new Vector3(-norm.x * 2, 0f, -norm.z * 2);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
