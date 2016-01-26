using UnityEngine;
using System.Collections;

public class CookieDisposer : MonoBehaviour {

	SlotMachineAI slotMachineAI;

	void Start()
	{
		slotMachineAI = GameObject.Find("SlotMachine").GetComponent<SlotMachineAI>();
	}

	void OnTriggerEnter (Collider other) 
	{
		Debug.Log("cookie inserted!");
		Destroy(other.gameObject);
		slotMachineAI.coinInserted();
	}
	

}
