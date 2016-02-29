using UnityEngine;
using System.Collections;
using System;

public class CoinInsertedState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("CoinInsertedState - enter");
		base.enter(slotMachineAI);
		slotMachineAI.enableLever();
        slotMachineAI.raiseSign("PullLever");
    }

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("CoinInsertedState - exit");
		base.exit(slotMachineAI);
		slotMachineAI.disableLever();
        slotMachineAI.lowSign("PullLever");
    }

	// events
	public override void leverPulledReceived(System.Object sender, EventArgs args)
	{
		Debug.Log("lever pulled received");
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		fsm.setState(new SpinningState());
	}
}
