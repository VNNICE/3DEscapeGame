using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float height;
    public float speed = 10f;
    private Rigidbody rigidbody;
    [SerializeField] private GameObject goalText;
    private bool GoalOn;
    [SerializeField] private ParticleSystem ExpObj;
    [SerializeField] private GameObject GOtxt;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 30;
    [SerializeField] GameObject RestartButton;

    // Start is called before the first frame update
    void Start()
    {
        height = this.transform.position.y - 3;
        GOtxt.gameObject.SetActive(false);
        rigidbody = GetComponent<Rigidbody>();
        goalText.SetActive(false);
        GoalOn = false;
        RestartButton.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kill")
        {
            KIlling();
        }
        if (collision.gameObject.tag == "Bounce")
        {
            StartCoroutine(waitKeyInput(1.0f));
        }
        if (collision.gameObject.tag == "Jump")
        {
            StartCoroutine(waitKeyInput(0.5f));
        }
    }



    private void KIlling()
    {
        this.gameObject.SetActive(false);
        ExpObj.transform.position = this.transform.position;
        ExpObj.Play();
        GOtxt.gameObject.SetActive(true);
        RestartButton.SetActive(true);
    }

    IEnumerator waitKeyInput(float x)
    {
        this.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(x); 
        this.GetComponent<PlayerController>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            rigidbody.AddForce(rigidbody.velocity.x * 0.8f, 0, -rigidbody.velocity.z * 0.8f, ForceMode.Impulse);
            goalText.SetActive(true);
            GoalOn=true;
            RestartButton.SetActive(true);
            this.GetComponent<PlayerController>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        rigidbody.AddForce(x, 0, z, ForceMode.Impulse);
        if (this.transform.position.y < height)
        {
            KIlling();
        }
        var moveDirction = new Vector3(x, 0, z);
        if (moveDirction != Vector3.zero)
        { 
            transform.rotation = Quaternion.LookRotation(moveDirction);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletGb = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
            var bulletRb = bulletGb.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(bulletGb, 2.0f);
        }
    }
}
