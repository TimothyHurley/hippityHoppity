using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] tile;
    
    //public GameObject leftTile;
    //public GameObject rightTile;

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
    {
        if (leftActive)
        {
            if (leftRed)
            {
                Instantiate(tile[1], tileSpawn[0].position, Quaternion.identity);
                //DestroyImmediate(tile[0], true);
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
        CheckGreen();
    }

    void CycleBackward()
    {

        CheckGreen();
    }

    void CycleRight()
    {

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
