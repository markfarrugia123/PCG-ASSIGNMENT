using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "car")
        {
            GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
            manager.GetComponent<GameManager>().checkpointInt++;
            Debug.Log($"Checkpoint{manager.GetComponent<GameManager>().checkpointInt}");
        }
    }
}
