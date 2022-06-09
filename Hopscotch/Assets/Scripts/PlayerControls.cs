using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] tile;

    public List<GameObject> leftClones = new List<GameObject>(); //lists tiles in the left column.
    public List<GameObject> rightClones = new List<GameObject>(); //lists tiles in the right column.

    public Transform[] tileSpawn;
    
    public bool leftAmber = false; //detects if left tile is amber.
    public bool leftGreen = false; //detects if left tile is green.
    public bool leftRed = false; //detects if left tile is red.
    public bool rightAmber = false; //detects if right tile is amber.
    public bool rightGreen = false; //detects if right tile is green.
    public bool rightRed = false; //detects if right tile is red.

    public float zLocation = 0; //player's location along the z axis.

    public int zDistance = 7; //distance player will move along the z axis.


    void Start()
    {
        leftClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().leftClones;
        rightClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().rightClones;
    }
    
    void Update()
    {
        if (leftGreen && rightGreen)
        {
            MovePlayer();
        }
        if (Input.GetKeyDown("w"))
        {
            CycleBoth();
        }
        if (Input.GetKeyDown("a"))
        {
            CycleLeft();
        }
        if (Input.GetKeyDown("s"))
        {
            CycleBackward();
        }
        if (Input.GetKeyDown("d"))
        {
            CycleRight();
        }
    }

    void OnTriggerEnter(Collider other)
        //sets leftActive and/or rightActive to true if respective tile is detected.
        //sets leftGreen and/or rightGreen to true if respective tile is green.
    {
        if (player[0].tag == "Left")
        {
            if (leftClones[0].tag == "Red")
            {
                leftAmber = false;
                leftGreen = false;
                leftRed = true;
            }
            if (leftClones[0].tag == "Amber")
            {
                leftAmber = true;
                leftGreen = false;
                leftRed = false;
            }
            if (leftClones[0].tag == "Green")
            {
                leftAmber = false;
                leftGreen = true;
                leftRed = false;
            }
        }
        if (player[1].tag == "Right")
        {
            if (rightClones[0].tag == "Red")
            {
                rightAmber = false;
                rightGreen = false;
                rightRed = true;
            }
            if (rightClones[0].tag == "Amber")
            {
                rightAmber = true;
                rightGreen = false;
                rightRed = false;
            }
            if (rightClones[0].tag == "Green")
            {
                rightAmber = false;
                rightGreen = true;
                rightRed = false;
            }
        }
    }

    void CycleBoth()
    {

    }

    void CycleLeft()
        //cycles left tile forward once (red --> amber --> green --> red).
    {
        if (leftRed)
        {
            GameObject.Destroy(leftClones[0]);
            leftClones.Add(leftClones[0] = Instantiate(tile[1], tileSpawn[0].position, Quaternion.identity));
        }
        if (leftAmber)
        {
            GameObject.Destroy(leftClones[0]);
            leftClones.Add(leftClones[0] = Instantiate(tile[2], tileSpawn[0].position, Quaternion.identity));
        }
        if (leftGreen)
        {
            GameObject.Destroy(leftClones[0]);
            leftClones.Add(leftClones[0] = Instantiate(tile[0], tileSpawn[0].position, Quaternion.identity));
        }
        RemoveElements();
    }

    void CycleBackward()
    {

    }

    void CycleRight()
        //cycles right tile forward once (red --> amber --> green --> red).
    {
        if (rightRed)
        {
            GameObject.Destroy(rightClones[0]);
            rightClones.Add(rightClones[0] = Instantiate(tile[1], tileSpawn[1].position, Quaternion.identity));
        }
        if (rightAmber)
        {
            GameObject.Destroy(rightClones[0]);
            rightClones.Add(rightClones[0] = Instantiate(tile[2], tileSpawn[1].position, Quaternion.identity));
        }
        if (rightGreen)
        {
            GameObject.Destroy(rightClones[0]);
            rightClones.Add(rightClones[0] = Instantiate(tile[0], tileSpawn[1].position, Quaternion.identity));
        }
        RemoveElements();
    }

    void MovePlayer()
        //checks if both tiles are green and, if yes, moves player up to next row of tiles.
    {
        leftGreen = false;
        rightGreen = false;
        for (float i = transform.position.z; i < zLocation + zDistance; i += zDistance)
        {
            transform.position = transform.position + new Vector3(0, 0, zDistance);
        }
        zLocation = transform.position.z;
        leftClones.RemoveAt(0);
        rightClones.RemoveAt(0);
    }

    void RemoveElements()
    {
        if (leftClones.Count > 5)
        {
            leftClones.RemoveAt(5);
            RemoveElements();
        }
        if (rightClones.Count > 5)
        {
            rightClones.RemoveAt(5);
            RemoveElements();
        }
    }
}
