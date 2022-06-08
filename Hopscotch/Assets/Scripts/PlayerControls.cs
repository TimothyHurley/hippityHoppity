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
    
    public bool leftActive = false; //checks if left tile exists.
    public bool rightActive = false; //checks if right tile exists.

    public bool leftAmber = false; //detects if left tile is amber.
    public bool leftGreen = false; //detects if left tile is green.
    public bool leftRed = false; //detects if left tile is red.
    public bool rightAmber = false; //detects if right tile is amber.
    public bool rightGreen = false; //detects if right tile is green.
    public bool rightRed = false; //detects if right tile is red.

    public int zDistance = 7; //distance player will move along the z axis.
    public int zLocation = 0; //player's location along the z axis.


    void Start()
    {
        leftClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().leftClones;
        rightClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().rightClones;
    }
    
    void Update()
    {
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
            leftActive = true;
            Debug.Log("leftActive = " + leftActive);
            if (other.gameObject.tag == "Red")
            {
                leftAmber = false;
                leftGreen = false;
                leftRed = true;
            }
            if (other.gameObject.tag == "Amber")
            {
                leftAmber = true;
                leftGreen = false;
                leftRed = false;
            }
            if (other.gameObject.tag == "Green")
            {
                leftAmber = false;
                leftGreen = true;
                leftRed = true;
            }
        }
        if (player[1].tag == "Right")
        {
            rightActive = true;
            Debug.Log("rightActive = " + rightActive);
            if (other.gameObject.tag == "Red")
            {
                rightAmber = false;
                rightGreen = false;
                rightRed = true;
            }
            if (other.gameObject.tag == "Amber")
            {
                rightAmber = true;
                rightGreen = false;
                rightRed = false;
            }
            if (other.gameObject.tag == "Green")
            {
                rightAmber = false;
                rightGreen = true;
                rightRed = false;
            }
        }
    }

    void CycleBoth()
    {

        CheckGreen();
    }

    void CycleLeft()
        //cycles left tile forward once (red --> amber --> green --> red).
    {
        if (leftActive)
        {
            if (leftRed)
            {
                Instantiate(tile[1], tileSpawn[0].position, Quaternion.identity);
            }
            if (leftAmber)
            {
                Instantiate(tile[2], tileSpawn[0].position, Quaternion.identity);
            }
            if (leftGreen)
            {
                Instantiate(tile[0], tileSpawn[0].position, Quaternion.identity);
            }
        }
        GameObject.Destroy(leftClones[0]);
        leftClones[0] = null;
        CheckGreen();
    }

    void CycleBackward()
    {

        CheckGreen();
    }

    void CycleRight()
        //cycles right tile forward once (red --> amber --> green --> red).
    {
        if (rightActive)
        {
            if (rightRed)
            {
                Instantiate(tile[1], tileSpawn[1].position, Quaternion.identity);
            }
            if (rightAmber)
            {
                Instantiate(tile[2], tileSpawn[1].position, Quaternion.identity);
            }
            if (rightGreen)
            {
                Instantiate(tile[0], tileSpawn[1].position, Quaternion.identity);
            }
        }
        GameObject.Destroy(rightClones[0]);
        rightClones[0] = null;
        CheckGreen();
    }

    void CheckGreen()
        //checks if both tiles are green and, if yes, moves player up to next row of tiles.
    {
        if (leftGreen && rightGreen)
        {
            for (int i = 0; i < zLocation; i += zDistance)
            {
                transform.position = transform.position + new Vector3(0, 0, zDistance);
            }
            zLocation = 0 + zDistance;
            Debug.Log("new transform = " + transform.position);
        }
        else
        {
            Debug.Log("sausage");
        }
    }
}
