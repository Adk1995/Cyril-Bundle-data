using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV : MonoBehaviour {
    public string[] serialNo;
    public string[] barcodeNo;
    public string[] id;
    public string[] manufacturer;
    public string[] brand;
    public string[] productDes;
    public string[] vegan;
    public string[] veg;
    public string[] nutFree;
    public string[] lactoseFree;
    public int i;

    private string[] barcodesSelected = { "33776011710", "16000275690", "14100074120",
                                           "38000402906", "21000612239", "21000615261",
                                           "16000277076", "54800030804", "51500012291", "38000576003"};
        // Use this for initialization
    void Start () {
        i = 0;

        ReadCSVFile();
	}
	
    public void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("/Users/adk1995/Desktop/VuforiaLocation/Assets/Data/BasicProductDetails.csv");
        bool endFile = false;
        while(!endFile)
        {
            string dataString = strReader.ReadLine();
            if(dataString == null)
            {
                endFile = true;
                break;
            }
            var data_values = dataString.Split(',');
            foreach(string barcode in barcodesSelected)
            {
                if(data_values[1].Equals(barcode))
                {
                    serialNo[i] = data_values[0];
                    barcodeNo[i] = data_values[1];
                    id[i] = data_values[2];
                    manufacturer[i] = data_values[3];
                    brand[i] = data_values[4];
                    productDes[i] = data_values[5];
                    vegan[i] = data_values[6];
                    veg[i] = data_values[7];
                    nutFree[i] = data_values[8];
                    lactoseFree[i] = data_values[4];
                 }
            }

            i++;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
