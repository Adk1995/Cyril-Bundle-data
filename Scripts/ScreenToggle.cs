using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class ScreenToggle : MonoBehaviour {
    public Button sceneChange;
	// Use this for initialization
	void Start () {
        sceneChange.onClick.AddListener(Change);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Change()
    {
        PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        if (pdt != null && pdt.IsActive)
        {
            pdt.Stop();
            //pdt.Start();
        }
        SceneManager.LoadScene(1);
    }
}
