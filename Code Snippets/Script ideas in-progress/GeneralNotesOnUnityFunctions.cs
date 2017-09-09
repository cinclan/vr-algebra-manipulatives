using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralNotesOnUnityFunctions : MonoBehaviour {

    //these are event functions! 
    //any event functions?
    //which to execute first?

    void Awake()
    {
        //always called before start
        //when gameObject is enabled

    }

	void Start () {
	//called before any frames are execuited
        //variable loading
	}
	
	void Update () {
	//most game code
        //called per frame
        //frequent use of Time.deltaTime
	}

    void LateUpdate()
    {
        //called per frame
        //only after Update() is called
     
    }

    void FixedUpdate()
    {
        //physics-based movement and calculation
        //not called per frame
        //called when it needs to be (such as when player moves block manually to rearrange or carry between game-tables)
        //built-in timer centered around performance stresses
        //if lagging, called multiple times per frame
        //otherwise, called around once per frame
        //no need to use Time.deltaTime
    }

}
