using UnityEngine;
using System.Collections;

public class Dispenser : MonoBehaviour {

    Vector3 direction;
    public GameObject cookie;

	void Start ()
    {
        direction = transform.FindChild("Target").position - transform.position;
	}
	
	public void Dispense(int n)
    {
        StartCoroutine(DispenseCo(n));
    }

    IEnumerator DispenseCo(int n)
    {
        for (int i = 1; i < n; i++)
        {
            GameObject newCookie = (GameObject)Instantiate(cookie, transform.position, Quaternion.identity);
            newCookie.GetComponent<Rigidbody>().AddForce(direction*100);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
