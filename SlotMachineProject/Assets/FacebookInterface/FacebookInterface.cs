using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.UI;
using System;

public class FacebookInterface: MonoBehaviour {

	/*
	 * 
	 * LOGIN WILL PROMPT FOR USER ACCESS TOKEN:
	 * CAADD8fplJywBAFcggN60exTvVFoAKA44IxzZB01FFcaDNim7aZAZCrVPys6kLyZC6Awg0RZBPDDXTtt2ZCnzulhnL4DjZBbw7TOZALRTS66qxHs5QBVjdd6BF30KW4d5ZCqQHN9uU2GU1fF4doEx7DbPczQIDYM8A8ZB6A3Yn1crmPqiF9I03SEIRYBXYS5VKbsi2fZCR6aHEZBBIgZDZD
	 * 
	 * APP NAME:
	 * kitty_cookie_slot
	 * 
	 * APP ID:
	 * 215444055467820
	 * 
	 */


	/**********************************************/
	//			UTILITY METHODS					   //
	/**********************************************/


	public void FbGetFriends()
	{
		// FB.API("/me?fields=friends.limit(10).fields(first_name,id)")
	}

	public void FbGetPicture()
	{
		FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPictureCallBack);

	}

	public void GetPictureCallBack(IGraphResult result)
	{
		//set the texture to the wheel
		GameObject.Find("Manager").GetComponent<Manager>().SetWheelsTexture(result.Texture);
	}



	/**********************************************/
	//			LOGIN AND AUTH					   //
	/**********************************************/

	public event EventHandler initializationFinishedEvent;

	void Start(){
		//FBInit ();
	}

	public void FBInit(){
		Debug.Log ("FB INITIALISED");
		FB.Init (InitCallback, OnHideUnity);
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();

			var perms = new List<string>(){"public_profile", "email", "user_friends"};
			FB.LogInWithReadPermissions(perms, AuthCallback);

		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}



	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
			initializationFinishedEvent.Invoke (this, null);

		} else {
			Debug.Log("User cancelled login");
		}
	}
		
	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}



}
