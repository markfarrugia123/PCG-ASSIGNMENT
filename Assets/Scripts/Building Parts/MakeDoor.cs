using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDoor : MonoBehaviour
{
    private GameObject blankPlane;
    private List<GameObject> buildings = new List<GameObject>();
    private List<GameObject> doorEgos = new List<GameObject>();
    private Vector3 vector1 = new Vector3(0, 0, 0);

    private int DoorEgoNum;

   
    public void BuildDoor(int egonum)
    {
        CreateEGOs();
        MakeDoorMain();
        DoorSides();
        ArrangeDoor();      
        foreach(GameObject doorParts in doorEgos)
        {
            doorParts.transform.parent = GetComponent<BuildingBase>().EGOS[egonum].transform;
        }
        GetComponent<BuildingBase>().egoNum++;
    }

    private void ArrangeDoor()
    {
        //position
        doorEgos[0].transform.position = new Vector3(0, 0, 0);
        doorEgos[1].transform.position = new Vector3(-10, 0, -10);
        doorEgos[2].transform.position = new Vector3(-10, 50, 30);
        doorEgos[3].transform.position = new Vector3(-10, 0, 30);
        //rotation
        doorEgos[0].transform.Rotate(0, 0, 90);
        doorEgos[1].transform.Rotate(0, 0, 90);
        doorEgos[2].transform.Rotate(0, 90, 0);
        doorEgos[3].transform.Rotate(0, 0, 90);
    }

    public void MakeDoorMain()
    {
       
        for (int i = 0; i < 3; i++)
        {
           for (int j = 0; j < 5; j++)
           {
               blankPlane = new GameObject();
               buildings.Add(blankPlane);
               blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
               blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(0));
               blankPlane.transform.parent = doorEgos[DoorEgoNum].transform;
           }           
        }
        DoorEgoNum++;
    }

    public void DoorSides()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int j = 0; j < 5; j++)
            {
                blankPlane = new GameObject();
                buildings.Add(blankPlane);
                blankPlane.transform.position = new Vector3(j * 10, 0, 0);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(4));
                blankPlane.transform.parent = doorEgos[DoorEgoNum].transform;
            }            
            DoorEgoNum++;
        }        
    }
    

    public void CreateEGOs()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Door part{(i + 1).ToString()}";    
            doorEgos.Add(EGO);
        }
    }
}

