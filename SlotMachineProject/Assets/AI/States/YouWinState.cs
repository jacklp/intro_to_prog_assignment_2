using UnityEngine;
using System.Collections;
using System;

public class YouWinState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouWinState - enter");
		base.enter(slotMachineAI);
	}

	public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouWinState - exit");
		base.exit(slotMachineAI);
	}

	// events

}
