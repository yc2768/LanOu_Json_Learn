using UnityEngine;
using System.Collections;
using System.Text;
using LitJson;
using System.IO;

public class JsonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //WriteJsonToFile();
        ReadJsonFromFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WriteJsonToFile()
    {
        StringBuilder strB = new StringBuilder();
        JsonWriter jsWriter = new JsonWriter(strB);
        jsWriter.WriteObjectStart();
        jsWriter.WritePropertyName("Property1");
        jsWriter.Write("value1");

        jsWriter.WritePropertyName("arr");
        jsWriter.WriteArrayStart();

        jsWriter.WriteObjectStart();
        jsWriter.WritePropertyName("item1");
        jsWriter.Write("item1Value");
        jsWriter.WriteObjectEnd();

        jsWriter.WriteObjectStart();
        jsWriter.WritePropertyName("item2");
        jsWriter.Write("item2Value");
        jsWriter.WriteObjectEnd();
        jsWriter.WriteArrayEnd();

        jsWriter.WriteObjectEnd();

        string filePath = Application.dataPath + "/first.json";
        StreamWriter sw = File.CreateText(filePath);
        sw.WriteLine(strB);
        sw.Close();
    }

    public void ReadJsonFromFile()
    {
        string filePath = Application.dataPath + "/first.json";
        StreamReader rd = new StreamReader(filePath);
        string str = rd.ReadToEnd();
        JsonData jd = JsonMapper.ToObject(str);
        JsonData arr = jd["arr"];
         Debug.Log(arr[0]["item1"]);
        Debug.Log(arr[1]["item2"]);
    }

}
