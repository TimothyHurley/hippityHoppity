using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles_Quad : MonoBehaviour
{
    public GameObject[] tile;

    public List<GameObject> clonesOne = new List<GameObject>(); //lists tiles in column one.
    public List<GameObject> clonesTwo = new List<GameObject>(); //lists tiles in column two.
    public List<GameObject> clonesThree = new List<GameObject>(); //lists tiles in column three.
    public List<GameObject> clonesFour = new List<GameObject>(); //lists tiles in column four.

    [HideInInspector] public float zSpawn; //z value of first tile spawn.

    [HideInInspector] public int count = 0; //counts how many tiles have spawned.
    [HideInInspector] public int countStop = 8; //identifies when count should stop.
    [HideInInspector] public int limit = 8; //limits number of tile spawns per column.
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
        GenerateOne();
        GenerateTwo();
        GenerateThree();
        GenerateFour();
        if (count < countStop)
        {
            Generate();
        }
    }

    public void GenerateOne()
    //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 spawnOne = new Vector3(-6, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                clonesOne.Add(Instantiate(tile[0], spawnOne, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                clonesOne.Add(Instantiate(tile[1], spawnOne, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clonesOne.Add(Instantiate(tile[2], spawnOne, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        clonesOne.Add(Instantiate(tile[0], spawnOne, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        clonesOne.Add(Instantiate(tile[1], spawnOne, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }

    public void GenerateTwo()
    //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 spawnTwo = new Vector3(1, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                clonesTwo.Add(Instantiate(tile[0], spawnTwo, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                clonesTwo.Add(Instantiate(tile[1], spawnTwo, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clonesTwo.Add(Instantiate(tile[2], spawnTwo, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        clonesTwo.Add(Instantiate(tile[0], spawnTwo, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        clonesTwo.Add(Instantiate(tile[1], spawnTwo, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }

    public void GenerateThree()
    //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 spawnThree = new Vector3(8, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                clonesThree.Add(Instantiate(tile[0], spawnThree, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                clonesThree.Add(Instantiate(tile[1], spawnThree, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clonesThree.Add(Instantiate(tile[2], spawnThree, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        clonesThree.Add(Instantiate(tile[0], spawnThree, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        clonesThree.Add(Instantiate(tile[1], spawnThree, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }

    public void GenerateFour()
    //generates a random tile in the left column.
    {
        for (int i = 0; i < (limit * zDistance); i += zDistance)
        {
            Vector3 spawnFour = new Vector3(15, 0, i + zSpawn);
            number = Random.Range(0, 3);
            if (number == 0)
            {
                clonesFour.Add(Instantiate(tile[0], spawnFour, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 1)
            {
                clonesFour.Add(Instantiate(tile[1], spawnFour, Quaternion.identity));
                limitGreen = limitGreen + 1;
            }
            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clonesFour.Add(Instantiate(tile[2], spawnFour, Quaternion.identity));
                    limitGreen = 0;
                }
                else
                {
                    number = Random.Range(0, 2);
                    if (number == 0)
                    {
                        clonesFour.Add(Instantiate(tile[0], spawnFour, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                    if (number == 1)
                    {
                        clonesFour.Add(Instantiate(tile[1], spawnFour, Quaternion.identity));
                        limitGreen = limitGreen + 1;
                    }
                }
            }
            count = count + 1;
        }
    }
}
