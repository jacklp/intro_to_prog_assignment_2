using UnityEngine;
using System.Collections.Generic;

namespace Facebook.Unity
{

	public class FacebookQueries : MonoBehaviour {

		// Use this for initialization
		void Start () 
		{
			//FB.Init(this.OnInitComplete);
			Debug.Log("FB.Init() called with " + FB.AppId);
		}
		
		void OnInitComplete()
		{
			FBLogin();
		}

		public void FBLogin()
		{
			List<string> perms = new List<string>() { "public_profile, email", "user_friends" };
			FB.LogInWithReadPermissions(perms, AuthCallBack);
		}
 
		void AuthCallBack(ILoginResult result)
		{
			if (FB.IsLoggedIn)
			{
				// AccessToken class will have session details
				var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
				// Print current access token's User ID
				Debug.Log(aToken.UserId);
				// Print current access token's granted permissions
				foreach (string perm in aToken.Permissions) {
					Debug.Log(perm);
				}
				//DealWithFBMenus(true);
			} 
			else 
			{
				Debug.Log("User cancelled login");
				//DealWithFBMenus(false);
			}
		}

		
	}
}
