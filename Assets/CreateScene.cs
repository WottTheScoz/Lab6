using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public int SizeOfForest;
    public int StonesRequired;
    public GameObject[] Trees;
    public GameObject[] Stones;
    public GameObject cubePrefab;
    public float spacing = 1.0f;

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

        //Changes the plane's color to red.
        Material renderer = plane.GetComponent<Renderer>().material;
        renderer.color = Color.red;
    }

    void CreateRandomForest()
    {
        foreach (GameObject Trees in Trees)
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(Random.Range(0, 5), 1, Random.Range(0, 5));
            cylinder.transform.localScale = new Vector3(Random.Range(0.1f, 2f), 1, Random.Range(0.1f, 2f));

            //Changes the color of the cylinder to a random shade of green.
            Material renderer = cylinder.GetComponent<Renderer>().material;
            renderer.color = new Color(0f, Random.Range(0.5f, 1f), 0f, 1f);
        }
    }

    void CreatePyramid()
    {
        int pyramidHeight = 5; 
        float spacing = 1.1f;

        float baseLayerWidth = (pyramidHeight - 1) * spacing;

        // Center the base layer
        Vector3 baseLayerCenterOffset = new Vector3(-baseLayerWidth / 2, 1.5f, -baseLayerWidth / 2);

        for (int level = 0; level < pyramidHeight; level++)
        {
            int layerSize = pyramidHeight - level;
            float layerWidth = (layerSize - 1) * spacing;

            Vector3 layerCenterOffset = new Vector3(-layerWidth / 2, level * spacing - 0.2f, -layerWidth / 2);

            for (int row = 0; row < layerSize; row++)
            {
                for (int col = 0; col < layerSize; col++)
                {
                    Vector3 spawnPosition = new Vector3(col * spacing, -0.5f, row * spacing) + baseLayerCenterOffset + layerCenterOffset;
                    GameObject primitiveObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    primitiveObject.transform.position = spawnPosition;
                    ColorPyramid(level, primitiveObject);
                }
            }
        }
    }

    //Gives color to the Pyramid based on the cube's current level.
    void ColorPyramid(int level, GameObject Primitive)
    {
        //Gets the primitive's renderer.
        Material renderer = Primitive.GetComponent<Renderer>().material;

        //Creates two new colors: orange and light red.
        Color Orange = new Color(1f, 0.6f, 0f, 1f);
        Color LightRed = new Color(1f, 0.5f, 0.5f, 1f);

        //The value of level decides the primitive's color.
        switch (level)
        {
            case 0:
                renderer.color = Color.yellow;
                break;
            case 1:
                renderer.color = Orange;
                break;
            case 2:
                renderer.color = LightRed;
                break;
            case 3:
                renderer.color = Color.magenta;
                break;
            case 4:
                renderer.color = Color.red;
                break;
            default:
                Debug.Log("Error in ColorPyramid");
                break;
        }
    }
}