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
		Debug.Log ("Manager: Facebook Initialized");
		facebookInterface.FbGetPicture ();
	}

	public void SetWheelsTexture(Texture2D texture)
	{
		Debug.Log ("Manager: Texture retrieved");
		GameObject.Find ("Image1").GetComponent<Renderer> ().material.mainTexture = texture;
	}


}
