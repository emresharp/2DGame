using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButtonController : MonoBehaviour
{

    public void Level1Button()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Level4Button()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Level5Button()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Levels");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Levels");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
