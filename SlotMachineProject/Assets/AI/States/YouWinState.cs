using UnityEngine;
using System.Collections;
using System;

public class YouWinState : SlotMachineAIState 
{	

	public override void enter (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouWinState - enter");
		base.enter(slotMachineAI);
		slotMachineAI.StartTimer(2f);

        slotMachineAI.raiseSign("YouWinSign");
        slotMachineAI.DispenseCookies(6);
        slotMachineAI.FireParticles();
    }

    public override void execute (SlotMachineAI slotMachineAI)
	{

	}

	public override void exit (SlotMachineAI slotMachineAI)
	{
		Debug.Log("YouWinState - exit");
		base.exit(slotMachineAI);

        slotMachineAI.lowSign("YouWinSign");
    }

    // events
    public override void timerFinishedReceived(System.Object sender, EventArgs args)
	{
		StateMachine<SlotMachineAI> fsm = ((SlotMachineAI)sender).getFSM();
		fsm.setState(new InsertCoinState());
	}
}
