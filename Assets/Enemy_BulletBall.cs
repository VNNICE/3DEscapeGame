using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject);
        }
    }
}
