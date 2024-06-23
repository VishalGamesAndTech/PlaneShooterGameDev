using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContolScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject gameOverMenu;
    public GameObject levelComplete;
    public GameObject endText;
    public GameObject startText;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        startText.SetActive(true);
        endText.SetActive(false);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        gameOverMenu.SetActive(false);
        levelComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        PauseButton.SetActive(false );
    }
    public void resumeButton()
    {
        
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PauseButton.SetActive(true);
    }
    public void quitButton()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        PauseButton.SetActive(false);
    }
    public IEnumerator LevelComplete()
    {
       
        yield return new WaitForSeconds(2f);
        endText.SetActive(true);
        PauseButton.SetActive(false);
        
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelComplete.SetActive(true);
       


    }
  
 
}
