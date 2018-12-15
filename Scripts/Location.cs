using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour {
    public Text text, difLat, difLon;
    public float latitude;
    public static bool withinRange=false;
    public float longitude;
    public float lat2, lon2;
    public GameObject treasure;
    public GameObject SpawnObjects;
    public Camera ARcamera;
    public static Location Instance { set; get; }
    // Use this for initialization
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {
            text.text = "User has not enabled GPS";
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait>0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            text.text = "Unable to determine device location";
            yield break;

        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        yield break;
    }
    private void Update()
    {

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        text.text = latitude + "    " + longitude;
        difLat.text = "Lat: " +Mathf.Abs(lat2 - latitude).ToString();
        difLon.text = "Lon: " +Mathf.Abs(lon2 - longitude).ToString();


        float dist = CalculateDistance(lat2, latitude, lon2, longitude);
        //text.text = dist.ToString();

       // if (dist< 300&&withinRange==false)
        if(withinRange==false)
        {
            text.text = "Success";
            treasure.SetActive(true);
            difLon.text = "Treasure loc" + treasure.transform.position.ToString();
            difLat.text = "ARcamera" + ARcamera.transform.position.ToString();
            withinRange = true;
            for (int i = 0; i < 10; i++)
            {
                Vector3 position = new Vector3(Random.Range(-8.0f, 8.0f), 0, Random.Range(0.0f, 15.0f));
                Instantiate(treasure, position, Quaternion.Euler(180,0,0));

            }

        }
       
    }

    private float CalculateDistance(float lat_1, float lat_2, float long_1, float long_2)
    {
        int R = 6371;
        var lat_rad_1 = Mathf.Deg2Rad * lat_1;
        var lat_rad_2 = Mathf.Deg2Rad * lat_2;
        var d_lat_rad = Mathf.Deg2Rad * (lat_2 - lat_1);
        var d_long_rad = Mathf.Deg2Rad * (long_2 - long_1);
        var a = Mathf.Pow(Mathf.Sin(d_lat_rad / 2), 2) + (Mathf.Pow(Mathf.Sin(d_long_rad / 2), 2) * Mathf.Cos(lat_rad_1) * Mathf.Cos(lat_rad_2));
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var total_dist = R * c * 1000; // convert to meters
        return total_dist;
    }

    public void Calculate_Distance(float long_a, float lat_a, float long_b, float lat_b)
    {
        float a_long_r, a_lat_r, p_long_r, p_lat_r, dist_x, dist_y, total_dist;
        a_long_r = DegToRad(long_a);
        a_lat_r = DegToRad(lat_a);
        p_long_r = DegToRad(long_b);
        p_lat_r = DegToRad(lat_b);
        dist_x = distX(a_long_r, p_long_r, a_lat_r, p_lat_r);
        dist_y = distY(a_lat_r, p_lat_r);
        total_dist = Final_distance(dist_x, dist_y);
        //prints the distance on the console
        text.text = total_dist.ToString();
    }
    public float DegToRad(float deg)
    {
        float temp;
        temp = (deg * 3.142f) / 180.0f;
        temp = Mathf.Tan(temp);
        return temp;

    }

    float distX(float lon_a, float lon_b, float lat_a, float lat_b)
    {
        float temp;
        float c;
        temp = (lat_b - lat_a);
        c = Mathf.Abs(temp * Mathf.Cos((lat_a + lat_b)) / 2);
        return c;
    }

    float distY(float lat_a, float lat_b)
    {
        float c;
        c = (lat_b - lat_a);
        return c;
    }

    float Final_distance(float x, float y)
    {
        float c;
        c = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f))) * 6371;
        return c;
    }

}

