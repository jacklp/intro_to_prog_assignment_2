using UnityEngine;
using System.Collections;
using System;

public class SlotMachineAIState : AIState<SlotMachineAI> 
{	

	#region AIState implementation
	public virtual void enter (SlotMachineAI slotMachineAI)
	{
		// subscribe the events
		slotMachineAI.coinInsertedEvent += coinInsertedReceived;
		slotMachineAI.leverPulledEvent += leverPulledReceived;
		slotMachineAI.allWheelsStoppedEvent += allWheelsStoppedReceived;
		slotMachineAI.timerFinishedEvent += timerFinishedReceived;
	}

	public virtual void execute (SlotMachineAI slotMachineAI)
	{

	}

	public virtual void exit (SlotMachineAI slotMachineAI)
	{
		// Clear the events
		slotMachineAI.coinInsertedEvent -= coinInsertedReceived;
		slotMachineAI.leverPulledEvent -= leverPulledReceived;
		slotMachineAI.allWheelsStoppedEvent -= allWheelsStoppedReceived;
		slotMachineAI.timerFinishedEvent -= timerFinishedReceived;
	}
	#endregion


	// events
	public virtual void coinInsertedReceived(System.Object sender, EventArgs args)
	{
		Debug.Log("event received in father");
	}
	public virtual void leverPulledReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
	public virtual void allWheelsStoppedReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
	public virtual void timerFinishedReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
}

