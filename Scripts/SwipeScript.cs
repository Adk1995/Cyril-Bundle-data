using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour {
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    public float throwObjectinXandY = 1f;
    public float throwForceInZ = 50f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {   
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            startPos = Input.GetTouch(0).position;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;

            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwObjectinXandY, -direction.y * throwObjectinXandY, throwForceInZ / timeInterval);
            Destroy(gameObject, 3f);
        }
	}
}
