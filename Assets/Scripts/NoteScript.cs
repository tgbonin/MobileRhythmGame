using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

    [SerializeField]
    float TimeToNoteHit;
    float TimeSinceSpawn;

    [SerializeField]
    Sprite Note_Green;
    [SerializeField]
    Sprite Note_Blue;
    [SerializeField]
    Sprite Note_Yellow;
    [SerializeField]
    Sprite Note_Red;
    [SerializeField]
    Sprite Note_Orange;

    Vector3 InitialScale;

    GameObject GameMngr;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        InitialScale = GameObject.FindGameObjectWithTag("TurtleBase").transform.localScale / 2;
        transform.localScale = Vector3.zero;
        GameMngr = GameObject.FindGameObjectWithTag("GameController");
    }

    public void SetSprite(int colour)
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Debug.Log(spriteRenderer.sprite.name);

        switch (colour){
            case 0:
                spriteRenderer.sprite = Note_Green;
                return;
            case 1:
                spriteRenderer.sprite = Note_Yellow ;
                return;
            case 2:
                spriteRenderer.sprite = Note_Blue;
                return;
            case 3:
                spriteRenderer.sprite = Note_Red;
                return;
            case 4:
                spriteRenderer.sprite = Note_Orange;
                return;
        }
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
