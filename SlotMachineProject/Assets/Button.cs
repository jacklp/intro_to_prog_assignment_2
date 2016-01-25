using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public bool _enabled;

	// Use this for initialization
	void Start () 
	{
		_enabled = true;
	}
	
	void OnMouseDown()
	{
		Debug.Log("Button pressed");
		if(_enabled) 
		{
			_enabled = false;
		}
		else
		{
			_enabled = true;
		}

	}
}
