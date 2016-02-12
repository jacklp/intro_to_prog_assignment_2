using UnityEngine;
using System.Collections;
using System;

public class Manager : MonoBehaviour {

	FacebookInterface facebookInterface;

    

	// Use this for initialization
	void Start () 
	{
		facebookInterface = GameObject.Find ("FacebookInterface").GetComponent<FacebookInterface> ();
		facebookInterface.initializationFinishedEvent += facebookInitialized;
		facebookInterface.FBInit ();
	}
	
	public void facebookInitialized(System.Object sender, EventArgs args)
	{
		//instead of just getting a picture.

		// 1. get friends' id's.
		// 2. get 3 of their pictures.
		Debug.Log ("Manager: Facebook Initialized");

		facebookInterface.FbGetPictures ();
	}
    
	public void SetWheelsTexture(Texture2D texture)
	{
		Debug.Log ("Manager: Texture retrieved");
		GameObject.Find ("Image1").GetComponent<Renderer> ().material.mainTexture = texture;
	}


}
