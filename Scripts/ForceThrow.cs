using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceThrow : MonoBehaviour {
    public float thrust = 1;
    public Rigidbody rb;
    public GameObject explosion;
    public GameObject monoText;
    public Camera ARcam;
    public Text text;
    public GameObject[] offers;

    Vector3 angle;
    // Use this for initialization
    void Start () {
        rb.GetComponent<Rigidbody>();
        angle = new Vector3(0, 5, 0);

        rb.AddForce(angle * 25);

	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.forward*thrust);
	}

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Blocks"))
        {
            text.text = other.name;
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            explosion.SetActive(true);
            Vector3 pos = other.transform.position;
            Destroy(other.transform.parent.gameObject,2);
            int i = Random.Range(0, 3);
            monoText = Instantiate(offers[i], pos, ARcam.transform.rotation );
            Destroy(monoText, 7);

        }

    }
}
