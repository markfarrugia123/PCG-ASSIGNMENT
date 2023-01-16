using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRoad : MonoBehaviour
{
    private GameObject blankPlane;
    private List<GameObject> Road;
    private List<GameObject> Ground;
    private List<GameObject> RoadPlanner;
    private List<GameObject> Corners;
    private List<GameObject> CompleteRoadPart;
    private Vector3 vector1 = new Vector3(0, 0, 0);
    private int RoadTileNum;
    private int CornerNum;
    public void BuildStreet()
    {
        CornerNum = 0;
        RoadTileNum = 0;
        Road = new List<GameObject>();
        Ground = new List<GameObject>();
        RoadPlanner = new List<GameObject>();
        CompleteRoadPart = new List<GameObject>();
        Corners = new List<GameObject>();
        CreateEGOs();
        MakeGround();
        RoadPlacerWidth();
        for (int i = 0; i < 96; i++)
        {
            MakeRoadMain();
            MakeCurb();
            RoadTileNum++;
        }       
        ArrangeRoad();
        ArrangeStreet();
        
    }
    public void CreateEGOs()
    {
        GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
        EGO.name = $"Ground";
        Ground.Add(EGO);
        for (int i = 0; i <100; i++)
        {
            EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Road part{(i + 1)}";
            RoadPlanner.Add(EGO);
        }
        for (int i = 0; i < 97; i++)
        {
            EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Road";
            Road.Add(EGO);
        }
        for (int i = 0; i < 4; i++)
        {
            EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Corner";
            Corners.Add(EGO);
        }
        for (int i = 0; i < 4; i++)
        {
            EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Road";
            CompleteRoadPart.Add(EGO);
        }
        int x = 0;
        foreach (GameObject road in RoadPlanner)
        {
            
            if(x < 30)
            {
                road.transform.parent = CompleteRoadPart[0].transform;
            }
            else if(x >=30 && x < 60)
            {
                road.transform.parent = CompleteRoadPart[1].transform;
            } 
            else if(x >=60 && x < 80)
            {
                road.transform.parent = CompleteRoadPart[2].transform;
            }
            else
            {
                road.transform.parent = CompleteRoadPart[3].transform;
            }
            x++;
        }

    }

    private void ArrangeStreet()
    {
        //position
        CompleteRoadPart[0].transform.position = new Vector3(313, -9.9f, 197);
        CompleteRoadPart[1].transform.position = new Vector3(603, -9.9f, 487);
        CompleteRoadPart[2].transform.position = new Vector3(363, -9.9f, 197);
        CompleteRoadPart[3].transform.position = new Vector3(363, -9.9f, 527);
        //rotation
        CompleteRoadPart[0].transform.Rotate(0, 0, 0);
        CompleteRoadPart[1].transform.Rotate(0, 180, 0);
        CompleteRoadPart[2].transform.Rotate(0, 90, 0);
        CompleteRoadPart[3].transform.Rotate(0, 90, 0);
        
    }

    private void ArrangeRoad()
    {
        int x = 0;
        int y = 0;
        int l = 0;
        for (int i = 0; i < 100; i++)
        {
            if (RoadPlanner[y].tag == "Corner 1")
            {
                MakeCorner();
                MakeCornerCurb();
                Corners[l].transform.position = new Vector3(0, 10, RoadPlanner[y].transform.position.z - 40);
                Corners[l].transform.parent = RoadPlanner[y].transform;
                CornerNum++;
                l++;
                y++;
            }
            else if (RoadPlanner[y].tag == "Corner 2")
            {
                MakeCorner();
                MakeCornerCurb();
                Corners[l].transform.position = new Vector3(0,10, RoadPlanner[y].transform.position.z +40 );
                Corners[l].transform.parent = RoadPlanner[y].transform;
                Corners[l].transform.Rotate(0, 90, 0);
                CornerNum++;
                l++;
                y++;

            }
            else 
            {                
                Road[x].transform.Rotate(0, 90, 0);                
                Road[x].transform.position = new Vector3(0, 10, RoadPlanner[y].transform.position.z);
                Road[x].transform.parent = RoadPlanner[y].transform;
                x++;                
                y++;             
            }

        }
    }
     public void RoadPlacerWidth()
     {
        int roadNum = 0;
        for (int i = 0; i < 4; i++)
        {            
            if(i < 2)
            {
                for (int x = 0; x < 30; x++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        blankPlane = new GameObject();
                        blankPlane.transform.position = new Vector3(j * 10, 0, x * 10);
                        blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(7));
                        if (roadNum == 0 || roadNum == 30)
                        {
                            RoadPlanner[roadNum].tag = "Corner 1";
                        }
                        else if (roadNum == 29 || roadNum == 59)
                        {
                            RoadPlanner[roadNum].tag = "Corner 2";
                        }
                        RoadPlanner[roadNum].transform.position = blankPlane.transform.position;
                        blankPlane.transform.parent = RoadPlanner[roadNum].transform;
                    }
                    roadNum++;
                }
            }
            else
            {
                for (int x = 0; x < 20; x++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        blankPlane = new GameObject();
                        blankPlane.transform.position = new Vector3(j * 10, 0, x * 10);
                        blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(7));
                        if (roadNum == 0 || roadNum == 30)
                        {
                            RoadPlanner[roadNum].tag = "Corner 1";
                        }
                        else if (roadNum == 29 || roadNum == 59)
                        {
                            RoadPlanner[roadNum].tag = "Corner 2";
                        }
                        RoadPlanner[roadNum].transform.position = blankPlane.transform.position;
                        blankPlane.transform.parent = RoadPlanner[roadNum].transform;
                    }
                    roadNum++;
                }
            }


        }        
     }   
 
    public void MakeGround()
    {
        
        for (int i = 1; i < 70; i++)
        {
            for (int j = 1; j < 80; j++)
            {
                blankPlane = new GameObject();
                Ground.Add(blankPlane);
                blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(2));
                blankPlane.transform.parent = Ground[0].transform;
            }
        }   
    }
    public void MakeRoadMain()
    {
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                blankPlane = new GameObject();                
                blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(7));
                blankPlane.transform.parent = Road[RoadTileNum].transform;
            }
        }
        
    }
    public void MakeCurb()
    {
        int side = 0;
        for (int x = 0; x < 2; x++)
        {
            for (int j = 0; j < 1; j++)
            {
                blankPlane = new GameObject();    
                if(side == 0)
                {
                    blankPlane.transform.position = new Vector3(j * 10, 10, -10);
                }
                else if(side == 1)
                {
                    blankPlane.transform.position = new Vector3(j * 10, 10, 50);
                }
                
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(10));
                blankPlane.transform.localScale = new Vector3(1, 1, 1);
                blankPlane.transform.parent = Road[RoadTileNum].transform;
            }
            side = 1;           
        }
        
    }
    public void MakeCorner()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                blankPlane = new GameObject();
                blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(7));
                blankPlane.transform.parent = Corners[CornerNum].transform;
            }
        }

    }
    public void MakeCornerCurb()
    {
        int side = 0;
        for (int x = 0; x < 2; x++)
        {
            for (int j = 0; j < 6; j++)
            {
                blankPlane = new GameObject();
                if (side == 0)
                {
                    blankPlane.transform.position = new Vector3(((j * 10)-10), 10, -10);
                }
                else if (side == 1)
                {
                    blankPlane.transform.position = new Vector3(-10,10 , j * 10);
                }

                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(10));
                blankPlane.transform.localScale = new Vector3(1, 1, 1);
                blankPlane.transform.parent = Corners[CornerNum].transform;
            }
            side = 1;
        }
    }
}
