using UnityEngine;
using System.Collections;
using System;

public class DecisorState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("DecisorState - enter");
		base.enter(slotMachineAI);

		StateMachine<SlotMachineAI> fsm = slotMachineAI.getFSM();
		if(slotMachineAI.wheelsEqual())
		{			
			//Debug.Log("All wheels stopped");
			fsm.setState(new YouWinState());
		}
		else
		{
			if(slotMachineAI.canAdjust())
			{
				fsm.setState(new AdjustState());
			}
			else
			{
				fsm.setState(new YouLoseState());
			}
		}
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("DecisorState - exit");
		base.exit(slotMachineAI);
	}

	// events

}
