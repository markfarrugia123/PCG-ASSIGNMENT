using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWall : MonoBehaviour
{
    private GameObject blankPlane;
    private List<GameObject> buildings;
    

    public void MakeWall10x10(int egoNum, int wallCount)
    {
        buildings = new List<GameObject>();
        for (int x = 0; x < wallCount; x++)
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    blankPlane = new GameObject();
                    buildings.Add(blankPlane);
                    blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                    blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(9));
                    blankPlane.transform.parent = GetComponent<BuildingBase>().EGOS[egoNum].transform;                       
                }
            }
            egoNum++;
            GetComponent<BuildingBase>().egoNum++;
        }
    }

    public void MakeWall12x12(int egoNum, int wallCount)
    {
        buildings = new List<GameObject>();
        int wallInt = 0;
        for (int x = 0; x < wallCount; x++)
        {            
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    blankPlane = new GameObject();
                    buildings.Add(blankPlane);
                    blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                    blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(9));
                    blankPlane.transform.parent = GetComponent<BuildingBase>().walls[wallInt].transform;
                    GetComponent<BuildingBase>().walls[wallInt].name = $"Wall {wallInt + 1}";                    
                }
            }
            wallInt++;
            egoNum++;            
        }
    }
}
