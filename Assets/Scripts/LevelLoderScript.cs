using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class LevelLoderScript : MonoBehaviour
{
    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reload()
    {
        SceneManager.LoadScene(currentIndex);
    }
    public void quitButton()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex+1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level01");
    }
}
