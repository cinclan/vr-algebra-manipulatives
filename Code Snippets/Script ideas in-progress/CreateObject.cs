using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using triggers -- walk through spawn

public class CreateObject : MonoBehaviour {

    //prefab specifications
    public Transform Spawnpoint; //position rotation
    public GameObject Prefab; //object to spawn

	void OnTriggerEnter () //when you enter or go through object
    { 
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
	}
}