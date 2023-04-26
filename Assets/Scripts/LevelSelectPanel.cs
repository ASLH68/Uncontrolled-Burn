using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPanel : MonoBehaviour
{
    [SerializeField] private LevelButton[] _allLevelButtons;

    // Start is called before the first frame update
    private void Start()
    {
        //_allLevelButtons = GameObject.FindObjectsOfType<LevelButton>();

        SetAllGrades();
    }
    
    /// <summary>
    /// Sets all the grades in the level select
    /// </summary>
    private void SetAllGrades()
    {
        for(int i = 0; i < _allLevelButtons.Length; i++)
        {
            _allLevelButtons[i].UpdateLevelScore(ScoreManager.main.AllGrades[i].ToString());
        }
    }
}
