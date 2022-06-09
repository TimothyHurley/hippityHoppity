using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    public GameObject[] tile;

    public List<GameObject> leftClones = new List<GameObject>(); //lists tiles in the left column.
    public List<GameObject> rightClones = new List<GameObject>(); //lists tiles in the right column.

    [HideInInspector] public float zSpawn; //z value of first tile spawn.
    
    [HideInInspector] public int count = 0; //counts how many tiles have spawned.
    [HideInInspector] public int countStop = 5; //identifies when count should stop.
    [HideInInspector] public int limit = 5; //limits number of tile spawns per column.
    [HideInInspector] public int limitGreen = 7; //limits frequency of green tile spawns by x amount.
    [HideInInspector] public int number = 0; //determines what tile will spawn (0 = red, 1 = amber, 2 = green).
    [HideInInspector] public int zDistance = 7; //distance between spawns along the z axis.


    void Awake()
    {
        Generate();
    }

    public void Generate()
        //generates random tiles until count is reached.
    {
        GenerateLeft();
        GenerateRight();
        if (count < countStop)
        {
            Generate();
        }
    }

    public void GenerateLeft()
        //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 leftSpawn = new Vector3(-6, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                leftClones.Add(Instantiate(tile[0], leftSpawn, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                leftClones.Add(Instantiate(tile[1], leftSpawn, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    leftClones.Add(Instantiate(tile[2], leftSpawn, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        leftClones.Add(Instantiate(tile[0], leftSpawn, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        leftClones.Add(Instantiate(tile[1], leftSpawn, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }

    public void GenerateRight()
        //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 rightSpawn = new Vector3(1, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                rightClones.Add(Instantiate(tile[0], rightSpawn, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                rightClones.Add(Instantiate(tile[1], rightSpawn, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    rightClones.Add(Instantiate(tile[2], rightSpawn, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        rightClones.Add(Instantiate(tile[0], rightSpawn, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        rightClones.Add(Instantiate(tile[1], rightSpawn, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }
}
