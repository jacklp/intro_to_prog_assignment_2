using UnityEngine;
using System.Collections;
using System;

public class AdjustState : SlotMachineAIState 
{	
	
	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("AdjustState - enter");
		base.enter(slotMachineAI);

		// enable buttons
		slotMachineAI.enableButtons();
		slotMachineAI.enableLever();
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("AdjustState - exit");
		base.exit(slotMachineAI);

		// disable buttons
		slotMachineAI.disableButtons();
		slotMachineAI.disableLever();
	}

	// events
	public override void leverPulledReceived(System.Object sender, EventArgs args)
	{
		Debug.Log("lever pulled received");
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		fsm.setState(new SpinningState());
	}
}
