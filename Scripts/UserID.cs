using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserID : MonoBehaviour {
    private string[] userID = { "ram", "mota", "adk", "shrey", "rohit", "abel", "chin" };
    public static string userIDForSession;
    public int i;
	// Use this for initialization
	void Start () {
        i = Random.Range(0, userID.Length);
        userIDForSession = userID[i];
	}
   
	// Update is called once per frame
	void Update () {
		
	}
   
}
