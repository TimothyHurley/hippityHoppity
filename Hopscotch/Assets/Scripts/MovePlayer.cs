using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject[] player;

    public bool leftGreen = false; //checks if left tile is green.
    public bool rightGreen = false; //checks if right tile is green.

    public int zDistance = 7; //distance player will move along the z axis.
    public int zLocation = 0; //player's location along the z axis.


    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            CheckGreen();
        }
    }

    void OnTriggerEnter(Collider other)
        //sets leftGreen and/or rightGreen to true if respective tile is green.
    {
        if (player[0].tag == "Left")
        {
            if (other.gameObject.tag == "Red")
            {
                leftGreen = false;
            }
            if (other.gameObject.tag == "Amber")
            {
                leftGreen = false;
            }
            if (other.gameObject.tag == "Green")
            {
                leftGreen = true;
            }
            Debug.Log("leftGreen = " + leftGreen);
        }
        if (player[1].tag == "Right")
        {
            if (other.gameObject.tag == "Red")
            {
                rightGreen = false;
            }
            if (other.gameObject.tag == "Amber")
            {
                rightGreen = false;
            }
            if (other.gameObject.tag == "Green")
            {
                rightGreen = true;
            }
            Debug.Log("rightGreen = " + rightGreen);
        }
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
