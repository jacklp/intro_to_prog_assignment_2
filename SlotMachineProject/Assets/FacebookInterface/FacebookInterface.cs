using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.UI;
using System;
using Facebook.MiniJSON;

public class FacebookInterface: MonoBehaviour {

	public event EventHandler initializationFinishedEvent;

	/*
	 * Initialise facebook through api.
	 */
	public void FBInit(){
		Debug.Log ("FB INITIALISED");
		FB.Init (InitCallback, OnHideUnity);
	}

	/*
	 * callback function from facebook initialise
	 */
	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();

			var perms = new List<string>(){"public_profile", "email", "user_friends", "user_photos"};
			FB.LogInWithReadPermissions(perms, AuthCallback);

		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	/*
	 * callback from facebook authorisation
	 */
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

	/*
	 * pause game whilst you login
	 */
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

	/*
	 * Gets facebook pictures
	 */

	public void FbGetPictures()
	{
		FB.API ("/me?fields=friends.limit(6).fields(first_name,id)", HttpMethod.GET, handleFriendIds);

	}

	public void handleFriendIds(IGraphResult result)
	{

		var dict = Json.Deserialize(result.RawResult) as Dictionary<string,object>;


		object friendsH;
		var friends = new List<object>();
		if(dict.TryGetValue ("friends", out friendsH)) {
			friends = (List<object>)(((Dictionary<string, object>)friendsH) ["data"]);

			for (int i = 0; i < 6; i++) {
				var friendDict = ((Dictionary<string,object>)(friends[i]));
				var friend = new Dictionary<string, string>();
				friend["id"] = (string)friendDict["id"];
				friend["first_name"] = (string)friendDict["first_name"];

				Debug.Log (friend ["id"] + friend ["first_name"]);

				FB.API( friend["id"] + "/picture?type=square&height=128&width=128", HttpMethod.GET, GetPictureCallBack);
			}
		}
	}

	/*
	 * getpicturecallback
	 */
	public void GetPictureCallBack(IGraphResult result)
	{
		//set the texture to the wheel
		GameObject.Find("Manager").GetComponent<Manager>().AddWheelsTexture(result.Texture);
	}

}
