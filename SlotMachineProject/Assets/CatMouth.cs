using UnityEngine;
using System.Collections;

public class CatMouth : MonoBehaviour 
{

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter () 
	{
		Debug.Log("Mouth detected cookie");
	}

	void OnTriggerExit () 
	{
		Debug.Log("Mouth lost cookie");
	}

	void OnTriggerStay () 
	{
		Debug.Log("Mouth attracting cookie");
	}
}
