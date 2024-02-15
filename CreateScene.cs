using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public int SizeOfForest;
    public int StonesRequired;
    public GameObject[] Trees;
    public GameObject[] Stones;

    int LoopAmount;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    void InitializeVariables()
    {
        SizeOfForest = 15;
        StonesRequired = 55;
        Trees = new GameObject[SizeOfForest];
        Stones = new GameObject[StonesRequired];
    }

    void CreateGround()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
    }

    void CreateRandomForest()
    {
        foreach(GameObject Trees in Trees)
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(Random.Range(0, 5), 1, Random.Range(0, 5));
            cylinder.transform.localScale = new Vector3(Random.Range(0.1f, 2f), 1, Random.Range(0.1f, 2f));
        }
    }

    void CreatePyramid()
    {
        int XPos;
        int YPos;
        foreach (GameObject Stones in Stones)
        {
            if(LoopAmount < 25)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(1, 1, 1);
                LoopAmount += 1;
            } 
            else if(LoopAmount < 41)
            {
                Debug.Log("Level 2");
                LoopAmount += 1;
            }
            else if(LoopAmount < 50)
            {
                Debug.Log("Level 3");
                LoopAmount += 1;
            }
            else
            {
                Debug.Log("Level 4");
                LoopAmount += 1;
            }
        }
    }
}
