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
		slotMachineAI.wheelStoppedEvent += wheelStoppedReceived;
		slotMachineAI.buttonActivatedEvent += buttonActivatedReceived;
		slotMachineAI.buttonDeactivatedEvent += buttonDeactivatedReceived;
	}

	public virtual void execute (SlotMachineAI slotMachineAI)
	{

	}

	public virtual void exit (SlotMachineAI slotMachineAI)
	{
		// Clear the events
		slotMachineAI.coinInsertedEvent -= coinInsertedReceived;
		slotMachineAI.leverPulledEvent -= leverPulledReceived;
		slotMachineAI.wheelStoppedEvent -= wheelStoppedReceived;
		slotMachineAI.buttonActivatedEvent -= buttonActivatedReceived;
		slotMachineAI.buttonDeactivatedEvent -= buttonDeactivatedReceived;
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
	public virtual void wheelStoppedReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
	public virtual void buttonActivatedReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
	public virtual void buttonDeactivatedReceived(System.Object sender, EventArgs args)
	{
//		Debug.Log("event received in father");
	}
}

