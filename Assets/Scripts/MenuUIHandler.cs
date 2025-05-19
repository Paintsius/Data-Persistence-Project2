using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        StartMenuManager.Instance.loadBestScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //StartMenuManager.Instance.save name and score
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deleteHighScore()
    {
        string filePath = Application.persistentDataPath + "/savefile.json";



        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("File deleted successfully.");
        }
        else
        {
            Debug.Log("File not found.");
        }

    }
}
