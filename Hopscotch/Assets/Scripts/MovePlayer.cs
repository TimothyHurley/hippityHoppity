using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject[] player;

    [HideInInspector] public List<GameObject> leftClones = new List<GameObject>(); //lists tiles in the left column.
    [HideInInspector] public List<GameObject> rightClones = new List<GameObject>(); //lists tiles in the right column.

    [HideInInspector] public bool leftAmber = false; //detects if left tile is amber.
    [HideInInspector] public bool leftGreen = false; //detects if left tile is green.
    [HideInInspector] public bool leftRed = false; //detects if left tile is red.
    [HideInInspector] public bool rightAmber = false; //detects if right tile is amber.
    [HideInInspector] public bool rightGreen = false; //detects if right tile is green.
    [HideInInspector] public bool rightRed = false; //detects if right tile is red.

    [HideInInspector] public int zDistance = 7; //distance player will move along the z axis.
    [HideInInspector] public int zLocation = 0; //player's location along the z axis.


    void Start()
    {
        leftClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().leftClones;
        rightClones = GameObject.FindGameObjectWithTag("Script").GetComponent<SpawnTiles>().rightClones;
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
        if (leftGreen && rightGreen)
        {
            Move();
        }
    }

    void Move()
        //checks if both tiles are green and, if yes, moves player up to next row of tiles.
    {
        for (int i = 0; i < zLocation; i += zDistance)
        {
            transform.position = transform.position + new Vector3(0, 0, zDistance);
        }
        zLocation = 0 + zDistance;
        Debug.Log("new transform = " + transform.position);
    }
}
