using UnityEngine;
using System.Collections;

//none of this works, but the idea is that instead of targeting painstakingly specific coordinates via a public vector3 array, utilize the tagging system
//unfortunately, not sure how to link tagged objects so that they attach at vertex points (and don't glitch into each-others colider boxes)

public class tagreader : MonoBehaviour {
		
	GameObject table1;
	void Start()
	{
		table1 = GameObject.FindWithTag("cube_pad_top_1");
		table1 = GameObject.FindWithTag("cube_pad_top_2");
		table1 = GameObject.FindWithTag("cube_pad_top_3");
		table1 = GameObject.FindWithTag("cube_pad_bottom_1");
		table1 = GameObject.FindWithTag("cube_pad_bottom_2");
		table1 = GameObject.FindWithTag("cube_pad_bottom_3");
		
		if ("cube_pad_top_1" = true)
			{
			print("A")
			else{print ""}
			}
		if ("cube_pad_top_2" = true)
			{
			print("A")
			else{print ""}
			}
		if ("cube_pad_top_3" = true)
			{
			print("A")
			else{print ""}
			}
		if ("cube_pad_top_1" = true)
			{
			print("A")
			else{print ""}
			}
		if ("cube_pad_top_1" = true)
			{
			print("A")
			else{print ""}
			}
			
			
	GameObject[] objects = GameObject.FindGameObjectsWithTag("myTag");
   
	
	void Update() 
	{
		transform.LookAt(table1.transform)
	}
	}
}
		