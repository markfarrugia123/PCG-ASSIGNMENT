using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public List<GameObject> windows;
    public List<GameObject> walls;
    public List<int> rng;
    public GameObject EGOPrefab;
    public GameObject EGO;
    public List<GameObject> EGOS;
    private Vector3 vector1 = new Vector3(0, 0, 0);
    public int egoNum;
    public int windowEgoNum;
    public bool bottomFloor;
    private int rngWindows;
    
    public void Build(bool bottomFloorBool)
    {
        //initialise lists
        windows = new List<GameObject>();
        walls = new List<GameObject>();
        rng = new List<int>();
        EGOS = new List<GameObject>();
        //initialise variables
        bottomFloor = bottomFloorBool;
        egoNum = 0;
        windowEgoNum = 0;
        rngWindows = 0;
        //start functions
        RNG();
        CreateEGOs();
        GetComponent<MakeWall>().MakeWall10x10(egoNum, 2);
        GetComponent<MakeWall>().MakeWall12x12(egoNum, 4);
        if(bottomFloorBool == true)
        {
            GetComponent<MakeDoor>().BuildDoor(egoNum);
            
        }
        else
        {
            egoNum++;
        }        
        for (int i = 0; i < rngWindows; i++)
        {
            GetComponent<MakeWindow>().BuildWindow(windowEgoNum);
            windowEgoNum++;
        }          
        ArrangeWindows();
        ArrangeBuilding();
        foreach (GameObject buildingPart in this.EGOS)
        {
            buildingPart.transform.parent = GetComponent<GameManager>().buildingParts[GetComponent<GameManager>().buildingNum].transform;
        }
    }

    private void RNG()
    {        
        //windowrng
        for (int i = 0; i < 4; i++)
        {
            rng.Add(Random.Range(0, 3));
            rngWindows += rng[i];
        }
        if (bottomFloor == true)
        {
            rngWindows -= rng[3];
            rng[3] = 0;
        }
    }

    private void ArrangeWindows()
    {       
        int rngNum=0;
        int windowNum = 0;
        foreach(GameObject wall in walls)
        {
            if (rng[rngNum] == 1)
            {
                windows[windowNum].transform.position = new Vector3(40, 5, 50);
                windows[windowNum].transform.Rotate(0, 0, 270);
                windows[windowNum].transform.parent = walls[rngNum].transform;
                windowNum++;
                wall.transform.parent = EGOS[egoNum].transform;
                egoNum++;
            }
            else if (rng[rngNum] == 2)
            {
                windows[windowNum].transform.position = new Vector3(40, 5, 20);
                windows[windowNum].transform.Rotate(0, 0, 270);
                windows[windowNum].transform.parent = walls[rngNum].transform;
                windows[windowNum+1].transform.position = new Vector3(40, 5, 80);
                windows[windowNum+1].transform.Rotate(0, 0, 270);
                windows[windowNum+1].transform.parent = walls[rngNum].transform;
                windowNum++;
                windowNum++;
                wall.transform.parent = EGOS[egoNum].transform;
                egoNum++;
            }
            else if (rng[rngNum] == 0)
            {
                wall.transform.parent = EGOS[egoNum].transform;
                egoNum++;
            }
            rngNum++;
        }
    }
    private void ArrangeBuilding()
    {
        //position
        EGOS[0].transform.position = new Vector3(0, 0, 0);
        EGOS[1].transform.position = new Vector3(0, 100, 0);
        EGOS[2].transform.position = new Vector3(40, 0, 100);
        EGOS[3].transform.position = new Vector3(0, -10, -10);
        EGOS[4].transform.position = new Vector3(100, -10, 110);
        EGOS[5].transform.position = new Vector3(110, -10, 0);
        EGOS[6].transform.position = new Vector3(-10, -10, 100);      
        //rotation
        EGOS[0].transform.Rotate(0, 0, 0);
        EGOS[1].transform.Rotate(0, 0, 0);
        EGOS[2].transform.Rotate(0, 90, 0);
        EGOS[3].transform.Rotate(0, 0, 90);
        EGOS[4].transform.Rotate(0, 180, 90);
        EGOS[5].transform.Rotate(0, 270, 90);
        EGOS[6].transform.Rotate(0, 90, 90);      
    }

    public void CreateEGOs()
    {        
        for (int i = 0; i < 10; i++)
        {
            EGO = Instantiate(EGOPrefab, vector1, Quaternion.identity);
            EGO.name = (i + 1).ToString();
            EGOS.Add(EGO);
        }
        for (int i = 0; i < rngWindows; i++)
        {                      
            windows.Add(Instantiate(EGOPrefab, vector1, Quaternion.identity));
        }
        for (int i = 0; i < 4; i++)
        {
            walls.Add(Instantiate(EGOPrefab, vector1, Quaternion.identity));
        }
    }    
}
