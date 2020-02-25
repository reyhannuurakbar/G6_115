using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextAsset data = Resources.Load<TextAsset>("data");

        string[] IoTdata = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < IoTdata.Length; i++)
        {
            string[] row = IoTdata[i].Split(new char[] { ',' });

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
