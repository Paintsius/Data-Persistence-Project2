using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    // create an static of an instance so only one
    public static StartMenuManager Instance;

    
    public int BestScore = 0;
    public string BestName = "empty";
    public string CurrentName = "empty";
    public InputField nameField;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestName;
        public string currentName;

    }

    public void SaveNameScore()
    {
        
        SaveData data = new SaveData();
        data.bestName = BestName;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void loadBestScore()
    {
        CurrentName = nameField.text;

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //TeamColor = data.TeamColor;
            BestScore = data.bestScore;
            
            BestName = data.bestName;
        }

    }



}
