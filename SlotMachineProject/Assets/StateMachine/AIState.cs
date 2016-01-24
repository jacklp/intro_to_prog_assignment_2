using UnityEngine;
using System.Collections;

public interface AIState<A> 
{
	//state life-cycle
	void enter(A agent);
	void execute(A agent);
	void exit(A agent);
}
