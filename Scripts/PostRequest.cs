using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostRequest : MonoBehaviour {
    public Button cart;
	// Use this for initialization
	void Start () {
        cart.onClick.AddListener(onCartCanvas);
    }
    public void onCartCanvas()
    {
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        string user = UserID.userIDForSession;

        form.AddField("username", user);
        //form.AddField("product", );

        Debug.Log(form.data);

        using (UnityWebRequest www = UnityWebRequest.Put("http://ec2-3-82-10-206.compute-1.amazonaws.com:3000/cart","form"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
