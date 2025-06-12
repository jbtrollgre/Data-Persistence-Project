using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameField;
    public Text bestScoreText;

    private void Start()
    {
        if (GameManager.Instance.PlayerName != "")
        {
            nameField.text = GameManager.Instance.PlayerName;
        }
        
        bestScoreText.text = "Best Score: " + GameManager.Instance.PlayerHighScore + " : " + GameManager.Instance.HighScore;
    }

    public void StartGame()
    {
        GameManager.Instance.SetName(nameField.text);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
