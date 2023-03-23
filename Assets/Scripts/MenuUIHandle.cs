using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandle : MonoBehaviour
{
    public TextMeshProUGUI bestScoreTxt;
    public TMP_InputField playerNameInput;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        MainManagerSave.Instance.LoadName();
        playerName = MainManagerSave.Instance.PlayerNameBS;
        bestScoreTxt.text = "Best Score - " + playerName + ": " + MainManagerSave.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        playerName = playerNameInput.text;
        MainManagerSave.Instance.PlayerName = playerName;
        MainManagerSave.Instance.SaveName();
        Debug.Log(playerName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        MainManagerSave.Instance.SaveName();
#else
        Application.Quit();
        MainManagerSave.Instance.SaveName();
#endif
    }
}
