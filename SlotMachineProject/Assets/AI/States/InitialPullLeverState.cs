using UnityEngine;
using System.Collections;
using System;

public class InitialPullLeverState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("InitialPullLeverState - enter");
		base.enter(slotMachineAI);
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("InitialPullLeverState - exit");
		base.exit(slotMachineAI);
	}

	// events
	public override void leverPulledReceived(System.Object sender, EventArgs args)
	{
		Debug.Log("lever pulled received");
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		//fsm.setState(new ScaredState());
	}
}
