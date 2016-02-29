using UnityEngine;
using System.Collections;
using System;

public class SlotMachineAI : MonoBehaviour {

	// global state variables --------------------------

	int maxSpinningsAllowedPerGame = 5;

	int spinningCounter = 0;
	public void incrementSpinningCounter()
	{
		spinningCounter++;
	}
	public void resetSpinningCounter()
	{
		spinningCounter = 0;
	}

	Button[] buttonsArray = new Button[3];
	//bool[] buttonsState = new bool[3];

	int spinningWheels = 0;

	Wheel[] wheelsArray = new Wheel[3];

	Lever lever;
	CatMouth mouth;
    Dispenser cookieDispenser;

	//---------------------------------------------------

	StateMachine<SlotMachineAI> _fsm;
	public StateMachine<SlotMachineAI> getFSM()
	{
		return _fsm;
	}

	// each state can subscribe to these events --------------------
	public event EventHandler coinInsertedEvent;
	public event EventHandler leverPulledEvent;
	public event EventHandler allWheelsStoppedEvent;
	public event EventHandler timerFinishedEvent;

	void Start()
	{
		_fsm = new StateMachine<SlotMachineAI>(this);
		_fsm.setState(new InsertCoinState());

		wheelsArray[0] = GameObject.Find("Wheel0").GetComponent<Wheel>();
		wheelsArray[1] = GameObject.Find("Wheel1").GetComponent<Wheel>();
		wheelsArray[2] = GameObject.Find("Wheel2").GetComponent<Wheel>();

		buttonsArray[0] = GameObject.Find("Button0").GetComponent<Button>();
		buttonsArray[1] = GameObject.Find("Button1").GetComponent<Button>();
		buttonsArray[2] = GameObject.Find("Button2").GetComponent<Button>();

		lever = GameObject.Find("Lever").GetComponent<Lever>();

		mouth = GameObject.Find("CatMouth").GetComponent<CatMouth>();

        cookieDispenser = GameObject.Find("CookieDispenser").GetComponent<Dispenser>();


    }
	
	void Update () 
	{
		//TO-DO: launch a coroutine that executes each x seconds
		_fsm.AIupdate();
	}

	// Checks -----------------------------------------------------
	public bool canAdjust()
	{
		if(spinningCounter < maxSpinningsAllowedPerGame) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public bool wheelsEqual()
	{
        if (wheelsArray[0].targetAngle == wheelsArray[1].targetAngle && wheelsArray[1].targetAngle == wheelsArray[2].targetAngle)
        {
            return true;
        }
        else
        {
            return false;
        }
	}

	// Actions to be used by the states ------------------------------

    public void DispenseCookies(int n)
    {
        cookieDispenser.Dispense(n);
    }

    public void raiseSign(string name)
    {
        GameObject.Find(name).GetComponent<Animator>().SetBool("activate", true);
    }
    public void lowSign(string name)
    {
        GameObject.Find(name).GetComponent<Animator>().SetBool("activate", false);
    }


    public void enableMouth()
	{
		if (mouth == null) mouth = GameObject.Find("CatMouth").GetComponent<CatMouth>();
		mouth._enabled = true;
	}
	public void disableMouth()
	{
		mouth._enabled = false;
	}


	public void enableButtons()
	{
		for(int i = 0; i < 3; i++)
		{
			buttonsArray[i].userInteractionEnabled = true;
		}
	}

	public void disableButtons()
	{
		for(int i = 0; i < 3; i++)
		{
			buttonsArray[i].userInteractionEnabled = false;
		}
	}

	public void enableLever()
	{
		lever.userInteractionEnabled = true;
	}

	public void disableLever()
	{
		lever.userInteractionEnabled = false;
	}

	public void resetButtons()
	{
		// set all buttons to activated (send events to the wheels)
		GameObject.Find("Button0").GetComponent<Button>()._enabled = true;
		GameObject.Find("Button1").GetComponent<Button>()._enabled = true;
		GameObject.Find("Button2").GetComponent<Button>()._enabled = true;
	}

	public void spinWheels()
	{
		
		spinningWheels = 0;
		for(int i = 0; i < 3; i++)
		{
			if(buttonsArray[i]._enabled) 
			{
				wheelsArray[i].startSpinning();
				spinningWheels++;
			}
		}

		// If all wheels are disabled -> fire allWheelsStoppedEvent
		if (spinningWheels == 0) allWheelsStoppedEvent.Invoke(this, null);
			
	}

	public void StartTimer(float time)
	{
		StartCoroutine(timer(time));
	}
	IEnumerator timer(float time)
	{		
		float timer = 0.0f;
		while(timer < time)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		timerFinished();
	}

		
	// events ---------------------------------------------------------
	private void timerFinished()
	{
		timerFinishedEvent.Invoke(this, null);
	}
	public void coinInserted()
	{
		coinInsertedEvent.Invoke(this, null);
	}
	public void leverPulled()
	{
		leverPulledEvent.Invoke(this, null);
	}
	public void wheelStopped()
	{
		Debug.Log("wheel stopped");
		spinningWheels--;
		if(spinningWheels <= 0)
			allWheelsStoppedEvent.Invoke(this, null);
	}

}
