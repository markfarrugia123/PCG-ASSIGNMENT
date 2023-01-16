using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    Material material;
    public Material ResourcesLoad(int x)
    {
        Material redMat = Resources.Load("Red", typeof(Material)) as Material;
        Material blueMat = Resources.Load("Blue", typeof(Material)) as Material;
        Material greenMat = Resources.Load("Green", typeof(Material)) as Material;
        Material pinkMat = Resources.Load("Pink", typeof(Material)) as Material;
        Material brownMat = Resources.Load("Brown", typeof(Material)) as Material;
        Material yellowMat = Resources.Load("Yellow", typeof(Material)) as Material;
        Material orangeMat = Resources.Load("Orange", typeof(Material)) as Material;
        Material whiteMat = Resources.Load("White", typeof(Material)) as Material;
        Material blackMat = Resources.Load("Black", typeof(Material)) as Material;
        Material darkBrownMat = Resources.Load("DarkBrown", typeof(Material)) as Material;
        Material grayMat = Resources.Load("Gray", typeof(Material)) as Material;
        

        switch (x)
        {
            case 0:
               return material = redMat;
            case 1:
                return material = blueMat;
            case 2:
                return material = greenMat;
            case 3:
                return material = pinkMat;
            case 4:
                return material = brownMat;
            case 5:
                return material = yellowMat;
            case 6:
                return material = orangeMat;
            case 7:
                return material = blackMat;
            case 8:
                return material = whiteMat;
            case 9:
                return material = darkBrownMat;
            case 10:
                return material = grayMat;

        }
       return material;
    }
}
