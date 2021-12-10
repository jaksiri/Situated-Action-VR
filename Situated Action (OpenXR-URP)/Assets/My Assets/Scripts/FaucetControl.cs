using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Water;
    public GameObject Openning;

    [SerializeField]
    private Vector3 spawnSpace;

    private bool waterRunning = false;
    private Coroutine co;

    public void StartWater()
    {
        Debug.Log("Water Running!");
        if (!waterRunning)
        {
            co = StartCoroutine(DropWater());
            waterRunning = true;
        }
        
    }

    public void StopWater()
    {
        Debug.Log("Water Stopped!");
        if (waterRunning)
        {
            StopCoroutine(co);
            waterRunning = false;
        }
    }


    private IEnumerator DropWater()
    {
        while (true)
        {
            var xPos = Openning.transform.position.x + UnityEngine.Random.Range(-1 * spawnSpace.x / 2, spawnSpace.x / 2);
            var yPos = Openning.transform.position.y;
            var zPos = Openning.transform.position.z + UnityEngine.Random.Range(-1 * spawnSpace.z / 2, spawnSpace.z / 2);
            GameObject newWater = GameObject.Instantiate(Water);
            newWater.transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(1f);
        }
    }
}
