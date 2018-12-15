using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowObjects : MonoBehaviour {
    public Camera FirstPersonCamera;
    public GameObject PlaceGameObject;
    public GameObject placedObject;
    public Transform startLocation;
    public Vector3 pos;
    public Text text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        
        Debug.Log("Touched");
        touch = Input.GetTouch(0);
        text.text = touch.ToString();
        Vector3 temp = startLocation.position;
        temp.x = touch.position.x;
        temp.y = touch.position.y;
        temp.z = 2;
        temp = FirstPersonCamera.ScreenToWorldPoint(temp);


        placedObject = Instantiate(PlaceGameObject, temp, FirstPersonCamera.transform.rotation);
        PlaceGameObject = placedObject;
    }
}
