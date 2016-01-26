using UnityEngine;
using System.Collections;
using System;

public class InsertCoinState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("InsertCoinsState - enter");
		base.enter(slotMachineAI);
		slotMachineAI.resetSpinningCounter();
		slotMachineAI.resetButtons();
		slotMachineAI.enableMouth();
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{
		
	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("InsertCoinsState - exit");
		base.exit(slotMachineAI);
		slotMachineAI.disableMouth();
	}

	// events
	public override void coinInsertedReceived(System.Object sender, EventArgs args)
	{
		Debug.Log("coin inserted received");
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		fsm.setState(new CoinInsertedState());

	}
}
