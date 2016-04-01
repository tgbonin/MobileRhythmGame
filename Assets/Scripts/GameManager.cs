using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private int score;
    public UnityEngine.UI.Text scoreText;

    private List<float> songTimingsList;
    private List<float> songNotePositionsList;

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

        GameObject.FindGameObjectWithTag("SongLoader").GetComponent<RhythmFileReader>().LoadSong("Assets/Songs/test.txt");
	}
	
	// Update is called once per frame
	void Update () {
        if (songPlaying)
        {
            timeSinceSongStart += Time.deltaTime * 1000;

            while(timeSinceSongStart >= songTimingsList[0])
            {
                //spawn note
                Debug.Log(songTimingsList[0] + ",   " + songNotePositionsList[0]);


                float rndX = Random.Range(-6.0f, 6.0f);
                float rndY = Random.Range(-2.0f, 2.0f);

                Instantiate(noteObjectPrefab, new Vector3(rndX, rndY, 0.0f), Quaternion.identity);


                songTimingsList.RemoveAt(0);
                songNotePositionsList.RemoveAt(0);

                if (songTimingsList.Count == 0) songPlaying = false;
                break;
            }
        }
	}

    public void OnSongLoaded(List<float> stl, List<float>snpl)
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
