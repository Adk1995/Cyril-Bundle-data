using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class SceneChange : MonoBehaviour {
    public Button buttonChange;
	// Use this for initialization
	void Start () {
        buttonChange.onClick.AddListener(Change);
        /*PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        if(pdt.IsActive)
        {
            pdt.Stop();
        }*/

	}

    

    // Update is called once per frame
    void Update () {
		
	}
    

    public void Change()
    {
        /*PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        if (pdt != null && pdt.IsActive)

        {
            //pdt.Stop();
            pdt.Start();
        }*/
        SceneManager.LoadScene(0);
    }
}
