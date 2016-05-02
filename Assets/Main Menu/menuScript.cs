using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;


	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }
	
	// Update is called once per frame
	public void ExitPress () {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void startLevel()
    {
        SceneManager.LoadScene("Hemmingson");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
