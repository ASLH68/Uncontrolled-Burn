using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager main;
    [SerializeField] List<LevelPoints> _allLevelPoints;
    [SerializeField]
    LevelPoints.Grades[] _allGrades;

    public LevelPoints.Grades[] AllGrades => _allGrades;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

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
        _allGrades = new LevelPoints.Grades[_allLevelPoints.Count];
    }

    /// <summary>
    /// Sets a value in _allGrades array
    /// </summary>
    /// <param name="pos"> pos being set </param>
    /// <param name="newGrade"> new grade being entered </param>
    public void SetGrade(int pos, LevelPoints.Grades newGrade)
    {
        _allGrades[pos] = newGrade;
    }

}
