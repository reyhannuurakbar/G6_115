using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    List<data> datas = new List<data>();
    public Text TextSuhu = null;
    public Text TextTekanan = null;
    public Text TextKetinggian = null;
    public Text TextCahaya = null;
    public Text TextKualitas = null;
    public Text TextKelembaban = null;
    public Text TextCuaca = null;

    // Start is called before the first frame update
    void Start()
    {
        // Baca csv
        TextAsset data = Resources.Load<TextAsset>("data");

        string[] IoTdata = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < IoTdata.Length-1; i++)
        {
            string[] row = IoTdata[i].Split(new char[] { ';' });
            
            // ini buat narik data ke list kalo engga kosong atau null
            //row kolom ke 1 nanti bisa diganti ke 0 kalo kondisinya ga make data dummy
            if (row[1] != "")
            {
                data d = new data();

                int.TryParse(row[0], out d.id);
                //double.TryParse(row[1], out d.suhu);
                d.suhu = row[1];
                //double.TryParse(row[2], out d.tekanan);
                d.tekanan = row[2];
                //int.TryParse(row[3], out d.ketinggian);
                d.tekanan = row[3];
                //int.TryParse(row[4], out d.cahaya);
                d.tekanan = row[4];
                //int.TryParse(row[5], out d.kualitas);
                d.tekanan = row[5];
                //double.TryParse(row[6], out d.kelembaban);
                d.kelembaban = row[6];
                d.cuaca = row[7];

                datas.Add(d);

                //ambil nilai terakhir cuma masih belum pas jadi perlu diperbaiki
                if(i == IoTdata.Length-3)
                {
                    TextSuhu.text = row[1];
                    TextTekanan.text = row[2];
                    TextKetinggian.text = row[3];
                    TextCahaya.text = row[4];
                    TextKualitas.text = row[5];
                    TextKelembaban.text = row[6];
                    TextCuaca.text = row[7];
                }
            }
            
        }

        foreach (data d in datas)
        {
            Debug.Log(d.tekanan);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
