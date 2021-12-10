using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private Transform spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LostPlane")
        {
            gameObject.transform.position = spawnpoint.transform.position;
            gameObject.transform.rotation = spawnpoint.transform.rotation;
            Debug.Log("Object Lost");
        }
    }
}
