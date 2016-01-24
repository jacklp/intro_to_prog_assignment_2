using UnityEngine;
using System.Collections;
using System;

public class SlotMachineAI : MonoBehaviour {

	StateMachine<SlotMachineAI> _fsm;
	public StateMachine<SlotMachineAI> getFSM()
	{
		return _fsm;
	}

	// each state can subscribe to these events --------------------
	public event EventHandler coinInsertedEvent;
	public event EventHandler leverPulledEvent;
	public event EventHandler wheelStoppedEvent;
	public event EventHandler buttonActivatedEvent;
	public event EventHandler buttonDeactivatedEvent;

	void Start()
	{
		_fsm = new StateMachine<SlotMachineAI>(this);
		_fsm.setState(new InsertCoinState());
	}
	
	void Update () 
	{
		//TO-DO: launch a coroutine that executes each x seconds
		_fsm.AIupdate();
	}

	// Actions to be used by the states ------------------------------
	public void reverseDirection()
	{
		Debug.Log("direction reverted");
	}
	public void moveToHomeCorner()
	{
		Debug.Log("moved to home corner");
	}
		
	// events ---------------------------------------------------------
	public void coinInserted()
	{
		coinInsertedEvent.Invoke(this, null);
	}
	public void leverPulled()
	{
		leverPulledEvent.Invoke(this, null);
	}
	public void wheelStopped()
	{
		wheelStoppedEvent.Invoke(this, null);
	}
	public void buttonActivated()
	{
		buttonActivatedEvent.Invoke(this, null);
	}
	public void buttonDeactivated()
	{
		buttonDeactivatedEvent.Invoke(this, null);
	}
}
