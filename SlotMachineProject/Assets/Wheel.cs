using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	float angulaVelocity = 360f; // degrees per second
	int numberOfSectors = 6;


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


	void GetPicture(Texture result){
		
	}

	public void startSpinning()
	{		
		//generate rnd number
		Random.seed = System.DateTime.Now.Millisecond + id*10;

		// random number of sectors of the wheel to spin.
		int rndSectorsToSpin = 6 + (int)(Random.value * 10);

		// angular space to cover
		float theta = rndSectorsToSpin * 360f/numberOfSectors;

		//how much time does it spin
		float time = theta / angulaVelocity;

		StartCoroutine(spin(time));
	}

	IEnumerator spin(float time)
	{
		Debug.Log("Wheel: time to wait = " + time);
		float timer = 0.0f;
		while(timer < time)
		{
			// rotate
			transform.Rotate(0f, 0f, -Time.deltaTime * angulaVelocity);

			timer += Time.deltaTime;
			yield return null;
		}

		// wheel reached its final position, snap to angle
		float targetAngle = 0f;

		float rotationZ = transform.rotation.eulerAngles.z % 360f;
		if(rotationZ <= 30f || rotationZ > 330f)
		{
			targetAngle = 0f;
		}else if(rotationZ <= 90f && rotationZ > 30f)
		{
			targetAngle = 60f;
		}else if(rotationZ <= 150f && rotationZ > 90f)
		{
			targetAngle = 120f;
		}else if(rotationZ <= 210f && rotationZ > 150f)
		{
			targetAngle = 180f;
		}else if(rotationZ <= 270f && rotationZ > 210f)
		{
			targetAngle = 240f;
		}else if(rotationZ <= 330f && rotationZ > 270f)
		{
			targetAngle = 300f;
		}

		Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetAngle);
		transform.eulerAngles = rot;


		slotMachineAI.wheelStopped();
	}
	

}
