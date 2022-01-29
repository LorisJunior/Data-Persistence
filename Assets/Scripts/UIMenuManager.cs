using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] InputField nameField;

    string recordName;
    string playerName;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.recordName != null)
        {
            recordName = GameManager.Instance.recordName;
            score = GameManager.Instance.score;

            text.text = $"Best Score : {recordName} : {score}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nameField.text.Length > 0)
        {
            playerName = nameField.text;
            GameManager.Instance.playerName = playerName;
        }
    }

    public void StartGame()
    {
        if (playerName.Length > 0)
        {
            SceneManager.LoadScene(1);
        }
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
