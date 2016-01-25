using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	public bool userInteractionEnabled = false;

	SlotMachineAI slotMachineAI;
	Animator animator;

	void Start () {
		slotMachineAI = GameObject.Find("SlotMachine").GetComponent<SlotMachineAI>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(userInteractionEnabled)
		{			
			slotMachineAI.leverPulled();
			animator.SetBool("pulling", true);
		}
	}
}
