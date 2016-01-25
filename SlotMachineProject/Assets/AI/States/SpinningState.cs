using UnityEngine;
using System.Collections;
using System;

public class SpinningState : SlotMachineAIState 
{	
	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("SpinningState - enter");
		base.enter(slotMachineAI);
		slotMachineAI.incrementSpinningCounter();

		// start wheels to spin
		slotMachineAI.spinWheels();
		slotMachineAI.resetButtons();
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{
		
	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("SpinningState - exit");
		base.exit(slotMachineAI);
	}

	// events
	public override void allWheelsStoppedReceived(System.Object sender, EventArgs args)
	{
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		Debug.Log("All wheels stopped");
		fsm.setState(new DecisorState());
	}
}