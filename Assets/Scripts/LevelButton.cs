using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNum;
    [SerializeField] private TextMeshProUGUI _levelScoreText;

    private void Start()
    {
        //_levelScoreText = transform.Find("Grade Text").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void GoToLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(_levelNum);
    }

    public void UpdateLevelScore(string newGrade)
    {
        _levelScoreText.text = newGrade;
    }
}
