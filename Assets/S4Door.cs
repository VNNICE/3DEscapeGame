using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S4Door : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject player;
    [SerializeField] GameObject text;
    bool _in_ = false;

    private void OnCollisionStay(Collision collision)
    {
        _in_ = true;
        text.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        _in_ = false;
        text.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_in_)
        {
            if (door.active == false && Input.GetKeyDown(KeyCode.V))
            {
                player.SetActive(false);
                //player.transform.position = new Vector3(-60f, 1f, 0f);
                door.SetActive(true);
            }
            else if (door.active == true && Input.GetKeyDown(KeyCode.V))
            {
                door.SetActive(false);
                player.SetActive(true);
                //player.transform.position = this.transform.position;
            }
        }
    }
}
