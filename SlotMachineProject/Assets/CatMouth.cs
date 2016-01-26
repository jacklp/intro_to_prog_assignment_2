using UnityEngine;
using System.Collections;

public class CatMouth : MonoBehaviour 
{

	public bool _enabled = true;

	void Start()
	{
	}

	void OnTriggerEnter (Collider other) 
	{
		if(_enabled)
		{
			Debug.Log("Mouth detected cookie");
			other.gameObject.GetComponent<Dragable>().disable();
		}
	}

	void OnTriggerExit (Collider other) 
	{
		//Debug.Log("Mouth lost cookie");
		//other.gameObject.GetComponent<Dragable>().enable();
	}

	void OnTriggerStay (Collider other) 
	{
		if(_enabled)
		{
			//Debug.Log("Mouth attracting cookie");
			Vector3 move = transform.position - other.transform.position;
			other.attachedRigidbody.AddForce(move * 20f);
		}
	}
}
