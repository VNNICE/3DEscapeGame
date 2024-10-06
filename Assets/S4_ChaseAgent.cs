using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S4_ChaseAgent : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] List<GameObject> waypoints = new List<GameObject>();
    private bool isChasing = false;
    private int currentWayPoint = 0;
    public float speed = 100f;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NavMeshHit hit;
            if (agent.Raycast(other.gameObject.transform.position, out hit) == true)
            {

            }
            else
            { 
                isChasing = true;
                agent.speed = speed;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = false;
            agent.speed = 3.5f;
        }
    }
    void Start()
    {
        agent.enabled = true;
        agent.destination = waypoints[currentWayPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        { 
            agent.destination = target.transform.position;
            return;
        }
        if (agent.remainingDistance < 0.5f)
        {
            SetNextWayPoint();
        }
    }
    private void SetNextWayPoint()
    { 
        currentWayPoint = (currentWayPoint + 1) % waypoints.Count;
        agent.destination = waypoints[currentWayPoint].transform.position;
    }
}
