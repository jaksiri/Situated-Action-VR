using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public int count;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            count++;
            Debug.Log($"Water In Goal: {count}");
        }
    }
}
