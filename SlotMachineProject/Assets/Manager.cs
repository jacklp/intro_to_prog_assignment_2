using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Manager : MonoBehaviour {

	FacebookInterface facebookInterface;
	List<Texture2D> images;
	GameObject wheel;
	GameObject plane;
	Renderer renderer;

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

			string materialName = "Material" + i.ToString();
			Material myMaterial = Resources.Load(materialName, typeof(Material)) as Material;
			myMaterial.mainTexture = images [i];

			//loop through the 3 different wheels and assign this material:
			for (int v = 0; v < 3; v++) {
				wheel = GameObject.Find ("Wheel" + v.ToString ());
				plane = wheel.transform.GetChild (i).gameObject;
				renderer = plane.GetComponent<Renderer> ();
				renderer.material = myMaterial;
			}
		}
	}
}
