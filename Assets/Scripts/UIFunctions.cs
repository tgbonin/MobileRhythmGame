using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {
	public void LoadGame() {
		SceneManager.LoadScene("TestArea");
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void QuitGame() {
		Debug.Log ("Quit");
		Application.Quit();
	}
}
