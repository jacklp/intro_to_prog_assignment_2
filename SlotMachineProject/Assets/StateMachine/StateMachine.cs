using UnityEngine;
using System.Collections;

public class StateMachine<A> 
{
	//Properties
	A _agent;
	public A getAgent() 
	{		
		return _agent;
	}

	AIState<A> currentState = null;
	public void setState(AIState<A> newState)
	{
		if(currentState != null) currentState.exit(_agent);
		currentState = newState;
		currentState.enter(_agent);
	}

	//Constructor
	public StateMachine(A agent)
	{
		_agent = agent;
	}

	//Update
	public void AIupdate () 
	{
		if(currentState != null)
			currentState.execute(_agent);
	}
}
