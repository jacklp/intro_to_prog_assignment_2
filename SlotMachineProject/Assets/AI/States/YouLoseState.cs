using UnityEngine;
using System.Collections;
using System;

public class YouLoseState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouLoseState - enter");
		base.enter(slotMachineAI);
		slotMachineAI.StartTimer(2f);
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouLoseState - exit");
		base.exit(slotMachineAI);
	}

	// events
	public override void timerFinishedReceived(System.Object sender, EventArgs args)
	{
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		fsm.setState(new InsertCoinState());
	}

}