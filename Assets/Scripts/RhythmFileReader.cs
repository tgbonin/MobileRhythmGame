using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class RhythmFileReader : MonoBehaviour {

    private List<float> times;
    private List<int> notePositions;
    private int bpm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadSong(string songName)
    {
        times = new List<float>();
        notePositions = new List<int>();

        TextAsset song = Resources.Load<TextAsset>("Songs/test") as TextAsset;
        string[] lines = song.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);
            string[] note = lines[i].Split(',');
            times.Add(float.Parse(note[0]));
            notePositions.Add(int.Parse(note[1]));
        }

        //string line;
        //StreamReader fileReader = new StreamReader(songName, Encoding.Default);
        //using (fileReader)
        //{
        //    bool firstLine = true;
        //    do
        //    {
        //        line = fileReader.ReadLine();
        //        //Debug.Log("Loaded Line: " + line);
        //
        //        if(line != null)
        //        {
        //            if (firstLine)
        //            {
        //                bpm = int.Parse(line);
        //                firstLine = false;
        //            }
        //            else
        //            {
        //                string[] note = line.Split(',');
        //                //Debug.Log(note[0] + "   " + note[1]);
        //                times.Add((float.Parse(note[0])));
        //                notePositions.Add((int.Parse(note[1])));
        //            }
        //        }
        //    }
        //    while (line != null);
        //}

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OnSongLoaded(times, notePositions);
    }
}
