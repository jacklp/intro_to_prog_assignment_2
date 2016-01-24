using UnityEngine;
using System.Collections;

public class DummyUser : MonoBehaviour {

	SlotMachineAI slotMachineAI;

	void Start () 
	{
		slotMachineAI = GameObject.Find("SlotMachine").GetComponent<SlotMachineAI>();
	}

	void Update () 
	{		
		if (Input.GetKeyDown(KeyCode.C)) slotMachineAI.coinInserted();
		if (Input.GetKeyDown(KeyCode.P)) slotMachineAI.leverPulled();
	}
}
