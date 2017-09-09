using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePositionVector : MonoBehaviour {
	public Vector3[] cubeUpperPositions; //array of viable upper cube positions -- user needs to manually record xyz position(s) where cube(s) instantiate in the inspector for the upper positions of the table 
    public Vector3[] cubeLowerPositions; //array of viable upper cube positions -- user needs to manually record xyz position(s) where cube(s) instantiate in the inspector for the lower positions of the table
    //note: going into the future, if using a perfectly scaled model cube (instead of a primitive prefab), it would make sense to snap vertices and perfectly align the spawn locations --> then record. As it stands now, the positions are not exact (I eyeballed it).
    
	//MASTERSCRIPTS: an empty GameObject that holds scripts (for easy access).
	
	public GameObject MASTERSCRIPTS;
    private GameObject sampleScaledCubePrefab;
    
	public bool slowInstantiation = true; //instantiates a clone of the sampleScaledCubePrefab model in the resources folder
	// Use this for initialization
	void Start () {
        sampleScaledCubePrefab = Resources.Load("Sample_Scaled_Primitive_Cube") as GameObject;
        if (slowInstantiation)
        {
            StartCoroutine(slowCubeInstantiation()); //by default, slowly populate cubes across game table
        }
        else
        {
            rapidCubeInstatiation(); //otherwise, instantaneously populate them all at once 
        }
	}
	//consider adding a public float to modify waitforseconds although, problem: not sure how to differentiate targeting upper cube vs lower cube instantiation positions)

	// Update is called once per frame
	void Update () {
		
	}

   //The private IEnum method instantiates rescaled cubes over a brief period to visualize placement and assign color randomly.
   //note: the method is done through recording positions, not snapping via tags or transforms (this is due to a coordinate issue)
   //The method returns 2 separate WaitForSeconds, first for 5% of a second, then 25% of a second to improve visualization (meaning, they both could be the same value, but the slight delay makes the instantiation changes easier to follow)
   //note: in a perfect world, only actual fraction pairs (like a/b or b/c) would actually have a unique color in the denominator (lower cube). Instead, it would be visualized as opaque white (representing a placeholder)
    private IEnumerator slowCubeInstantiation() //slow instantion method -- by default, instantiation speed is set to slow (so one can see cubes populate across the game table incrementally), however this is unnecessary visual flair and in a realistic game setting, rapidCubeInstatiation (below) makes more sense and wastes less of the user's time
    {
        for (int i = 0; i <= 6; i++)
        {
            GameObject newUpperCube = Instantiate(sampleScaledCubePrefab, cubeUpperPositions[i], Quaternion.identity);
            //Access the color script attached to the MASTERSCRIPTS object and pass the current object to the color assignment function.
            MASTERSCRIPTS.GetComponent<SampleAbstractColorAssignment>().AssignColor(newUpperCube);
            yield return new WaitForSeconds(0.05f);
            GameObject newLowerCube = Instantiate(sampleScaledCubePrefab, cubeLowerPositions[i], Quaternion.identity);
            //Access the color script attached to the MASTERSCRIPTS object and pass the current object to the color assignment function.
            MASTERSCRIPTS.GetComponent<SampleAbstractColorAssignment>().AssignColor(newLowerCube);
            yield return new WaitForSeconds(0.25f); //
        }
    }

    // Instantly instantiates cubes into upper and lower positions and assign color randomly. 
    private void rapidCubeInstatiation() //rapidCubeInstatiation method (if on, skips IEnumerator)
    {
        for (int i = 0; i <= 6; i++)
        {
            GameObject newUpperCube = Instantiate(sampleScaledCubePrefab, cubeUpperPositions[i], Quaternion.identity);
            //Access the color script attached to the MASTERSCRIPTS object and pass the current object to the color assignment function.
            MASTERSCRIPTS.GetComponent<SampleAbstractColorAssignment>().AssignColor(newUpperCube);

            GameObject newLowerCube = Instantiate(sampleScaledCubePrefab, cubeLowerPositions[i], Quaternion.identity);
            //Access the color script attached to the MASTERSCRIPTS object and pass the current object to the color assignment function.
            MASTERSCRIPTS.GetComponent<SampleAbstractColorAssignment>().AssignColor(newLowerCube);
        }
    }
}
