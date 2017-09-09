using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePositionVector : MonoBehaviour {
    public Vector3[] cubeUpperPositions; //manualy record vector3 xyz coords for each upper position (in inspector)
    public Vector3[] cubeLowerPositions; //manualy record vector3 xyz coords for each lower position (in inspector)

    public GameObject sampleScaledCubePrefab;

    public bool slowInstantiation = true;
	// Use this for initialization
	void Start () {
        if (slowInstantiation)
        {
            StartCoroutine(slowCubeInstantiation());
        }
        else
        {
            rapidCubeInstatiation();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Instantiate rescaled cubes over a brief period to visualize placement.
    // returns 2 separate WaitForSeconds, first for 5% of a second, then 25% of a second to improve visualization.
    private IEnumerator slowCubeInstantiation()
    {
        for (int i = 0; i <= 6; i++)
        {
            GameObject newUpperCube = Instantiate(sampleScaledCubePrefab, cubeUpperPositions[i], Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            GameObject newLowerCube = Instantiate(sampleScaledCubePrefab, cubeLowerPositions[i], Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
    }
    
    // Instantly instantiates cubes into upper and lower positions.
    private void rapidCubeInstatiation()
    {
        for (int i = 0; i <= 6; i++)
        {
            GameObject newUpperCube = Instantiate(sampleScaledCubePrefab, cubeUpperPositions[i], Quaternion.identity);
            GameObject newLowerCube = Instantiate(sampleScaledCubePrefab, cubeLowerPositions[i], Quaternion.identity);
        }
    }
}
