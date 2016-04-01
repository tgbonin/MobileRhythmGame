using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

    [SerializeField]
    float TimeToNoteHit;
    float TimeSinceSpawn;

    Vector3 InitialScale;

    GameObject GameMngr;

	// Use this for initialization
	void Start () {
        InitialScale = transform.localScale;
        transform.localScale = Vector3.zero;
        GameMngr = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        TimeSinceSpawn += Time.deltaTime;
        Vector3 scale = Vector3.Lerp(Vector3.zero, InitialScale, TimeSinceSpawn / TimeToNoteHit);

        transform.localScale = scale;

        if(TimeSinceSpawn > (TimeToNoteHit + 0.4f)) Destroy(gameObject.transform.parent.gameObject);
    }

    void OnMouseDown()
    {
        float missedTime = TimeToNoteHit - TimeSinceSpawn;

        if(missedTime < 0.05)
        {
            //Perfect!
            GameMngr.GetComponent<GameManager>().AddToScore(1000);
        }
        else if(missedTime < 0.1)
        {
            //Great
            GameMngr.GetComponent<GameManager>().AddToScore(750);
        }
        else if (missedTime < 0.2)
        {
            //Good
            GameMngr.GetComponent<GameManager>().AddToScore(500);
        }
        else if (missedTime < 0.3)
        {
            //OK
            GameMngr.GetComponent<GameManager>().AddToScore(250);
        }
        else if (missedTime < 0.4)
        {
            //Bad
            GameMngr.GetComponent<GameManager>().AddToScore(100);
        }
        else
        {
            //Missed
        }
        Destroy(gameObject.transform.parent.gameObject);
    }
}
