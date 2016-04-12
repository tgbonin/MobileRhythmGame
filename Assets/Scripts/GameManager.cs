using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private int score;
    public UnityEngine.UI.Text scoreText;

    private List<float> songTimingsList;
    private List<int> songNotePositionsList;

    private Vector2[] notePositions;

    private bool songPlaying;

    private float timeSinceSongStart;

    [SerializeField]
    int secondsBeforeSongStart;

    [SerializeField]
    GameObject noteObjectPrefab;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScoreCounter();
        songPlaying = false;
        timeSinceSongStart = 0.0f;

        notePositions = new Vector2[5];
        notePositions[0] = new Vector2(-0.05f, -1.16f); //green
        notePositions[1] = new Vector2(-1.099f, 0.006f); //yellow
        notePositions[2] = new Vector2(-0.914f, -2.585f); //blue
        notePositions[3] = new Vector2(0.846f, 0.145f); //red
        notePositions[4] = new Vector2(1.027f, -2.43f); //orange

        GameObject.FindGameObjectWithTag("SongLoader").GetComponent<RhythmFileReader>().LoadSong("Assets/Songs/test.txt");
	}
	
	// Update is called once per frame
	void Update () {
        if (songPlaying)
        {
            timeSinceSongStart += Time.deltaTime * 1000;

            while(timeSinceSongStart >= songTimingsList[0])
            {
                GameObject nO = Instantiate(noteObjectPrefab, notePositions[songNotePositionsList[0]], Quaternion.identity) as GameObject;
                nO.GetComponentInChildren<NoteScript>().SetSprite(songNotePositionsList[0]);

                songTimingsList.RemoveAt(0);
                songNotePositionsList.RemoveAt(0);

                if (songTimingsList.Count == 0) songPlaying = false;
                break;
            }
        }
	}

    public void OnSongLoaded(List<float> stl, List<int>snpl)
    {
        songTimingsList = stl;
        songNotePositionsList = snpl;

        timeSinceSongStart = -3000;

        songPlaying = true;
    }

    public void AddToScore (int s)
    {
        score += s;
        UpdateScoreCounter();
    }

    void UpdateScoreCounter()
    {
        scoreText.text = "Score: " + score;
    }
}
