using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    //[SerializeField] private int starsNeeded;
    //[SerializeField] private int whichLevel;

    public void GoToLevel(int level)
    {
        //if()
        // I'll code the star system later, we're just going through tutorials for now

        // I could probably change this to a string, just so the game doesn't break
        SceneManager.LoadScene(level);
    }
}
