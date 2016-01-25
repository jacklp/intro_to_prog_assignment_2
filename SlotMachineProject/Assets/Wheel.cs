using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	static int idGenerator = 0;
	static int generateId()
	{
		idGenerator++;
		return idGenerator;
	}

	public int id;

	SlotMachineAI slotMachineAI;

	void Start () 
	{
		id = generateId();
		slotMachineAI = GameObject.Find("SlotMachine").GetComponent<SlotMachineAI>();
	}

	public void startSpinning()
	{		
		//generate rnd number
		Random.seed = System.DateTime.Now.Millisecond + id*10;
		float rnd = 2.0f + Random.value*1.5f;
		StartCoroutine(spin(rnd));
	}

	IEnumerator spin(float time)
	{
		Debug.Log("Wheel: time to wait = " + time);
		float timer = 0.0f;
		while(timer < time)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		slotMachineAI.wheelStopped();
	}
	

}
