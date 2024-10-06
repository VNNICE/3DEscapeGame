using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBall : MonoBehaviour
{
    [SerializeField] ParticleSystem ExpObj;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            ExpObj.transform.position = collision.gameObject.transform.position;
            ExpObj.Play();

        }
    }
}
