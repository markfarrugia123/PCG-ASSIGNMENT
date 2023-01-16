using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   

    [SerializeField] Camera cam;


    private Vector3 vector1 = new Vector3(0, 0, 0);


    public List<GameObject> buildingParts = new List<GameObject> ();
    public List<GameObject> finishedBuilding = new List<GameObject>();

    public int buildingNum;
    public int buildingPartsInt;
    public int buildingPartsInt2;
    public int checkpointInt;
    
    

    // Start is called before the first frame update
    void Start()
    {
        checkpointInt = 0;
        buildingPartsInt = 0;
        CreateEGOs();
        GetComponent<MakeRoad>().BuildStreet();
        for (int i = 0; i < 5; i++)
        {
            CreateBuilding();
        }
        ArrangeBuilding();
        Instantiate(Resources.Load("Prometheus"), new Vector3(10, 10, 10), Quaternion.identity);        
        cam.transform.parent = GameObject.FindGameObjectWithTag("car").transform;
        GameObject car = GameObject.FindGameObjectWithTag("car");
        car.transform.position = new Vector3(335, 12, 320);

    }

    public void CreateEGOs()
    {
        for (int i = 0; i < 26; i++)
        {
            GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Part {i + 1}";
            buildingParts.Add(EGO);
        }
        for (int i = 0; i < 6; i++)
        {
            GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Building {i + 1}";
            finishedBuilding.Add(EGO);
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject EGO = Instantiate(GetComponent<BuildingBase>().EGOPrefab, vector1, Quaternion.identity);
            EGO.name = $"Collider {i + 1}";
            BoxCollider boxCollider = EGO.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            if (i == 0)
            {
                EGO.transform.position = new Vector3(330, 15, 334);
                EGO.transform.Rotate(0, 90, 0);
            }
            else if (i == 1)
            {
                EGO.transform.position = new Vector3(582, 15, 334);
                EGO.transform.Rotate(0, 90, 0);
            }
            else if (i == 2)
            {
                EGO.transform.position = new Vector3(468, 15, 504);
                EGO.transform.Rotate(0, 0, 0);
            }
            else if (i == 3)
            {
                EGO.transform.position = new Vector3(468, 15, 174);
                EGO.transform.Rotate(0, 0, 0);
            }
            boxCollider.size = new Vector3(10, 20, 60);
            EGO.AddComponent<Checkpoint>();
            
        }
    }

    private void CreateBuilding()
    {        
        int height = Random.Range(2,5);
        for (int i = 0; i < height; i++)
        {
            if (i == 0)
            {
                GetComponent<BuildingBase>().Build(true);                
                finishedBuilding.Add(buildingParts[buildingPartsInt]);
                buildingParts[buildingNum].transform.parent = finishedBuilding[buildingPartsInt].transform;
                buildingNum++;
            }
            else
            {
                GetComponent<BuildingBase>().Build(false);                
                buildingParts[buildingNum].transform.position = new Vector3(0, (110*(i)), 0);
                finishedBuilding.Add(buildingParts[buildingPartsInt]);
                buildingParts[buildingNum].transform.parent = finishedBuilding[buildingPartsInt].transform;
                buildingNum++;
            }
            
        }
        buildingPartsInt++;
    }
    private void ArrangeBuilding()
    {
        //position
        finishedBuilding[0].transform.position = new Vector3(110, 0, 433);
        finishedBuilding[1].transform.position = new Vector3(111, 0, 289);
        finishedBuilding[2].transform.position = new Vector3(415, 0, 118);
        finishedBuilding[3].transform.position = new Vector3(746, 0, 302);
        finishedBuilding[4].transform.position = new Vector3(530, -10, 679);

        //rotation
        finishedBuilding[0].transform.Rotate(0, 0, 0);
        finishedBuilding[1].transform.Rotate(0, 90, 0);
        finishedBuilding[2].transform.Rotate(0, 90, 0);
        finishedBuilding[3].transform.Rotate(0, -90, 0);
        finishedBuilding[4].transform.Rotate(0, 180, 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpointInt == 5 && SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (checkpointInt == 5 && SceneManager.GetActiveScene().name == "Level 2")
        {
            Application.Quit();
        }
    }
    
   
}
