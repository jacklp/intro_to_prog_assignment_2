using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Manager : MonoBehaviour {

	FacebookInterface facebookInterface;
	List<Texture2D> images;



	// Use this for initialization
	void Start () 
	{
		facebookInterface = GameObject.Find ("FacebookInterface").GetComponent<FacebookInterface> ();
		facebookInterface.initializationFinishedEvent += facebookInitialized;
		facebookInterface.FBInit ();

		images = new List<Texture2D>();
	}

	public void facebookInitialized(System.Object sender, EventArgs args)
	{
		//instead of just getting a picture.

		// 1. get friends' id's.
		// 2. get 3 of their pictures.
		Debug.Log ("Manager: Facebook Initialized");

		facebookInterface.FbGetPictures ();
	}

	public void AddWheelsTexture(Texture2D texture)
	{
		images.Add (texture);
		if (images.Count == 6) {
			SetWheelsTexture ();
		}
	}

	public void SetWheelsTexture(){
		for (int i = 0; i < images.Count; i++) {

			Material myMaterial = Resources.Load("Materials/Material" + i.ToString(), typeof(Material)) as Material;
			myMaterial.mainTexture = images [i];
			//GameObject.Find ("Material" + i.ToString()).GetComponent<Renderer> ().material.mainTexture = images[i];
		}
		Debug.Log ("materials assigned textures");
	}
}
