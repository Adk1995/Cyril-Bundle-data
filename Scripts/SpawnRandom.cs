using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnRandom : MonoBehaviour {
    public Vector3 center;
    public Vector3 size;
    public Transform[] objectTransforms;
    public Text text;
	// Use this for initialization
	void Start () {

        for (var i = 0; i < 10; i++)
        {
           objectTransforms[i].position = Random.insideUnitSphere * 10;
        }
	}
	
	// Update is called once per frame
	void Update () {
        text.text = objectTransforms[3].position.ToString();
	}
}
