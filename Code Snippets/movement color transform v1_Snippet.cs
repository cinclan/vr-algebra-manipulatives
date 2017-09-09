using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollower : MonoBehaviour {
    public Transform movingObject; //every object in a scene has transform. This one is used to store and manipulate the position, rotation, and scale of the object.

    public Vector3[] leftRight = new Vector3[2]; //Vector3 represents a movement of 3D vectors and points 

    public bool goRight = true;//initialization of transform direction to the right table

    private bool isMoving = false;//initialization of transform movement on start to zero

	// Use this for initialization
	void Start () {
        leftRight[0] = new Vector3(movingObject.position.x - 2, movingObject.position.y, movingObject.position.z); //initializes a vector3 on playmode start that acts as the initial position of the game object-2 meters (from the starting "rest" coordinate) along the x axis
        leftRight[1] = new Vector3(movingObject.position.x + 2, movingObject.position.y, movingObject.position.z); //initializes a vector3 on playmode start that acts as the final transform position of the game object at +2 meters (from the starting "rest" coordinate) along the x axis

        gameObject.transform.SetParent(movingObject); //sets "movingObject" as the new parent of the player gameObject ("movingObject" is the name of the primitive cube in the asset hierarchy)
        movingObject.position = leftRight[0]; //initializes the rest coordinate of the game object to leftRight[0] (which gets a new Vector3 transform)

        movingObject.gameObject.GetComponent<Renderer>().material.color = Color.red; //sets the object material color to red once play mode is activated
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false) //when user activates play mode, and presses space bar -- game object is not moving. Then it will transform to the new position)
        {
            StartCoroutine(MovementControl()); //initialization of movement coroutine
        }
	}

    // IEnumerator belongs to .NET and represents an object. It allows one to stop the process of an action at a specific moment, and return to an original position (or nothing) whenever needed. In this context, it's used to make the game object wait after it has translated (resting in the new table position), and only after pressing the spacebar again, will it reverse translate back to it's initial position (-2 along the x axis from 0)
    // This IEnumerator uses a While Loop coupled with a WaitForSeconds return type (typed by virtue of using IEnumerator). It creates the smooth movement effect without the risk
    // of surpassing the left and right movement limits of using a Vector3.Lerp (a means of linearly interpolating between two vectors given a float time "t"). The color change occurs in the break termination statement at the top of the While Loop.
    // 
    // <returns> A time delay of 0.01 seconds for every iteration of the While Loop. Smooths movement without a Vector3.Lerp.</returns>
    IEnumerator MovementControl()
    {
        isMoving = true;
        while (true)
        {
            if ((Vector3.Distance(movingObject.position, leftRight[1]) < 0.01f && goRight == true) || (Vector3.Distance(movingObject.position, leftRight[0]) < 0.01f && goRight == false))
            {

                //This if-statement assigns the movingObject's upon successful completion of movement. Left: Red; Right: Green. An old idea that moving a variable from one table to another would change the variable CMYK color to it's opposite to represent negative or positive transforms. Later I realized this was flawed and would be confusiong without literal positive negative indicators. 
                if (goRight == true)
                {
                    movingObject.gameObject.GetComponent<Renderer>().material.color = Color.green; //turn green on 100%translation
                }
                else
                {
                    movingObject.gameObject.GetComponent<Renderer>().material.color = Color.red; //turn red on 100%translation
                }

                goRight = !goRight;
                isMoving = false;

                break;
            }
            if (goRight == true)
            {
                movingObject.Translate(0.1f, 0f, 0f); //if moving right, translate by an +x float value
            }
            else
            {
                movingObject.Translate(-0.1f, 0f, 0f); //otherwise, translate by an -x float value
            }
            //Delay next iteration by 0.01 seconds.
            yield return new WaitForSeconds(0.01f); //"WaitForSeconds" suspspends the couroutine execution for the given amount of seconds using scaled time
        }
    }
}
