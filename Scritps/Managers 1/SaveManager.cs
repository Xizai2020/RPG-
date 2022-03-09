using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : Singleton<SaveManager>
{
    private string sceneName="";
    public string SceneName
    {
        get
        {
            return PlayerPrefs.GetString(sceneName);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {

    }
    public void SavePlayerData()
    {
        Save(GameManager.Instance.playerCharterstate.characterDate, GameManager.Instance.playerCharterstate.characterDate.name);
        Save(GameManager.Instance.playerCharterstate.baseAttackData, GameManager.Instance.playerCharterstate.baseAttackData.name);
        Save(GameManager.Instance.playerCharterstate.attackData, GameManager.Instance.playerCharterstate.attackData.name);
    }
    public void LoadPlayerData()
    {
        Load(GameManager.Instance.playerCharterstate.characterDate, GameManager.Instance.playerCharterstate.characterDate.name);
        Load(GameManager.Instance.playerCharterstate.baseAttackData, GameManager.Instance.playerCharterstate.baseAttackData.name);
        Load(GameManager.Instance.playerCharterstate.attackData, GameManager.Instance.playerCharterstate.attackData.name);
    }
    public void SaveInvenQuest()
    {
        if (InventoryManager.Instance)
        {
            InventoryManager.Instance.SaveData();
        }
        if (QuestManager.Instance)
        {
            QuestManager.Instance.SaveQuestManager();
        }
    }
    public void Save(object data,string key)
    {
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.SetString(sceneName, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
    public void Load(object data,string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), data);
        }
    }
}
