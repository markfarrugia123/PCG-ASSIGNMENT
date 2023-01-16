using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWindow : MonoBehaviour
{
    private GameObject blankPlane;
    private List<GameObject> buildings;
    private List<GameObject> windowEgos;
    private Vector3 vector1 = new Vector3(0, 0, 0);
    private int WindowEgoNum;
    public void BuildWindow(int windowEgo)
    {
        WindowEgoNum = 0;
        buildings = new List<GameObject>();
        windowEgos = new List<GameObject>();
        CreateEGOs();
        MakeWindowMain();
        WindowSides();
        WindowInterior();
        ArrangeWindow();
        Debug.Log(windowEgo);
        foreach (GameObject windowParts in this.windowEgos)
        {
            windowParts.transform.parent = GetComponent<BuildingBase>().windows[windowEgo].transform;
        }
        GetComponent<BuildingBase>().windows[windowEgo].name = $"Window{windowEgo}";       
    }   
    
    private void ArrangeWindow()
    {
        //position
        windowEgos[0].transform.position = new Vector3(0, 0, 0);
        windowEgos[1].transform.position = new Vector3(-5, -5, -7.5f);
        windowEgos[2].transform.position = new Vector3(-5, 27.5f, 25);
        windowEgos[3].transform.position = new Vector3(-5, -5, 27.5f);
        windowEgos[4].transform.position = new Vector3(-5, -7.5f, 25);
        windowEgos[5].transform.position = new Vector3(-5, 0, 10);
        windowEgos[6].transform.position = new Vector3(-5, 10, 20);
        //rotation
        windowEgos[0].transform.Rotate(0, 0, 90);
        windowEgos[1].transform.Rotate(0, 0, 90);
        windowEgos[2].transform.Rotate(90, 90, 0);
        windowEgos[3].transform.Rotate(0, 0, 90);
        windowEgos[4].transform.Rotate(90, 0, -90);
        windowEgos[5].transform.Rotate(0, 0, 90);
        windowEgos[6].transform.Rotate(0, 90, 0);
    }

    public void MakeWindowMain()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                blankPlane = new GameObject();
                buildings.Add(blankPlane);
                blankPlane.transform.position = new Vector3(j * 10, 0, i * 10);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(1));
                blankPlane.transform.parent = windowEgos[WindowEgoNum].transform;
            }
        }
        WindowEgoNum++;
    }

    public void WindowSides()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int j = 0; j < 4; j++)
            {
                blankPlane = new GameObject();
                buildings.Add(blankPlane);
                blankPlane.transform.position = new Vector3(j * 10, 0, 0);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(4));
                blankPlane.transform.localScale = new Vector3(1, 1, 0.5f);
                blankPlane.transform.parent = windowEgos[WindowEgoNum].transform;
            }
            WindowEgoNum++;
        }
    }

    public void WindowInterior()
    {
        for (int x = 0; x < 2; x++)
        {
            for (int j = 0; j < 3; j++)
            {
                blankPlane = new GameObject();
                buildings.Add(blankPlane);
                blankPlane.transform.position = new Vector3(j * 10, 0, 0);
                blankPlane.AddComponent<Cube1>().CreateCube(GetComponent<Materials>().ResourcesLoad(7));
                blankPlane.transform.localScale = new Vector3(1, 0.5f, 0.5f);
                blankPlane.transform.parent = windowEgos[WindowEgoNum].transform;
            }
            WindowEgoNum++;
        }
    }


    public void CreateEGOs()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Window part{(i + 1)}";
            windowEgos.Add(EGO);
        }
    }
}
