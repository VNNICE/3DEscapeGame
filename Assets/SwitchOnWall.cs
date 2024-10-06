using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchOnWall : MonoBehaviour
{
    [SerializeField] GameObject SwitchWall;
    [SerializeField] GameObject DeadLine;
    public static bool startstage = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Player" && !startstage)
        {
            SwitchWall.transform.position += new Vector3(0, 1, 0);
            DeadLine.SetActive(false);
            startstage = true;
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
