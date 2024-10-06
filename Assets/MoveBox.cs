using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    bool change;

    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && !change)
        {
            change = true;
        }
        else if (collision.gameObject.tag == "Wall" && change)
        { 
            change = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            x += Time.deltaTime * 10;
        }
        else
        {
            x -= Time.deltaTime * 10;
        }
    }
    void FixedUpdate()
    {
            transform.position = new Vector3(x, y, z);
    }
}