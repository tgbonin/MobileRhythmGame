using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class RhythmFileReader : MonoBehaviour {

    private List<float> times;
    private List<float> notePositions;
    private int bpm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadSong(string songName)
    {
        times = new List<float>();
        notePositions = new List<float>();

        string line;
        StreamReader fileReader = new StreamReader(songName, Encoding.Default);
        using (fileReader)
        {
            bool firstLine = true;
            do
            {
                line = fileReader.ReadLine();

                if(line != null)
                {
                    if (firstLine)
                    {
                        bpm = int.Parse(line);
                    }
                    else
                    {
                        string[] note = line.Split(',');
                        times.Add((float.Parse(note[0])));
                        notePositions.Add((float.Parse(note[1])));
                    }
                }
            }
            while (line != null);
        }
    }
}
