using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public bool userInteractionEnabled = false;

	public bool _enabled;

	// Use this for initialization
	void Start () 
	{
		_enabled = true;
    }

    void Update()
    {
        if (_enabled && userInteractionEnabled)
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(255, 248, 0));

        }
        else
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(2, 57, 124, 255));
        }
    }

    void OnMouseDown()
	{
		if(userInteractionEnabled)
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
}
