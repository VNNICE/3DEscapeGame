using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAgent : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 30;
    [SerializeField] Transform player_position;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            agent.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            agent.enabled = false;
        }
    }
    public void Attack()
    {
        var bulletGb = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
        var bulletRb = bulletGb.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bulletGb, 2.0f);
    }

    IEnumerator DoAttack()
    {
        while (agent == true) { 
            Attack();
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = false;
        if (agent.enabled)
        {
            StartCoroutine("DoAttack");
            Debug.Log("follow start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
            agent.destination = target.transform.position;
        }
        var direction = player_position.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(direction);

    }
}
