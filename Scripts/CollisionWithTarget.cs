using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWithTarget : MonoBehaviour {
    public Text triggeredText;
    public int i = 0;
    public Renderer rend;
    public AudioSource bloop;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggeredText.text = "Collider: " + other.name + i.ToString();
            i++;
            rend.enabled = true;
            bloop.Play();

        }
    }
}
