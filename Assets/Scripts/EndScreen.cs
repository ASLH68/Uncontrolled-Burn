using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen main;

    [SerializeField] private GameObject _nextLvlButton;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        CheckLastLevel();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CheckLastLevel()
    {
        if(SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
        {
            HideNextLevelButton();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void HideNextLevelButton()
    {
        _nextLvlButton.SetActive(false);
    }
}
