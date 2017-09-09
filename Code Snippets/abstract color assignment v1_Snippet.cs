using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAbstractColorAssignment : MonoBehaviour {
    public List<Color> colorList; //allows complete control for additional colors (or redactions) within the inspector (so you don't end up with ugly rgb colors)
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Takes a passed GameObject and randomly assigns a color to its renderer (alpha auto set to opaque).
    // <param name="colorableObject">The object to be colored.</param>
    public void AssignColor(GameObject colorableObject)
    {
        try
        {
            if (colorList.Count > 0) //if colorList has no added user-chosen colors, cubes instantiate *randomly* as opaque-grey
            {
                Color c = colorList[Random.Range(0, colorList.Count)]; //user defined range of custom colors defaults to 0 unless changed in inspecttor
                //Force alpha value of Color c to maximum value (fully opaque).
                c.a = 255;

                colorableObject.GetComponent<Renderer>().material.color = c; //gets list of custom colors chosen by user (they will all be black unless individually modified) and applies them to each new instantiable cube object
            }
        }
        catch
        {
            Debug.Log("Object does not have a renderer component!");
        }
    }
}