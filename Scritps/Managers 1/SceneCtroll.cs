using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class SceneCtroll : Singleton<SceneCtroll> ,IEngGameServer
{
    GameObject player;
    public SceneFader sceneFaderPrefab;
    public GameObject playerPrefab;
    private NavMeshAgent playerAgent;
    private bool fadeFinshed;

    //加载进度界面
    public GameObject loadScree;
    public Slider slider;
    public Text text;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);

    }
    private void Start()
    {
        loadScree.gameObject.SetActive(false);
        GameManager.Instance.AddObserver(this);
        fadeFinshed = true;
    }
    IEnumerator LoadScene(string sceneName)
    {
        loadScree.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = "加载中……" + (operation.progress* 100).ToString("00") + "%";
            if (operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "加载中……" + 1 * 100 + "%";
                yield return new WaitForSeconds(0.1f);
                operation.allowSceneActivation = true;
                //loadScree.gameObject.SetActive(false);
            }
            yield return null;
        }

    }

    public void TranstionToDestion(Transtion transtionPoint)
    {
        switch (transtionPoint.transtateType)
        {
            case Transtion.TranstateType.SameScene:
                StartCoroutine(TranstionPoint(SceneManager.GetActiveScene().name, transtionPoint.destionTag));
                break;
            case Transtion.TranstateType.DiffentScene:
                //保存数据
                SaveManager.Instance.SavePlayerData();
                if (QuestManager.Instance)
                {
                    QuestManager.Instance.SaveQuestManager();
                }
                if (InventoryManager.Instance)
                {
                    InventoryManager.Instance.SaveData();
                }
                StartCoroutine(TranstionPoint(transtionPoint.sceneName, transtionPoint.destionTag));
                break;
        }
    }
    IEnumerator TranstionPoint(string sceneName,TranstionDestion.DestionTag destionTag)
    {


        
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            //yield return SceneManager.LoadSceneAsync(sceneName);
            yield return StartCoroutine(LoadScene(sceneName));
            yield return Instantiate(playerPrefab, GetDestion(destionTag).transform.position, GetDestion(destionTag).transform.rotation);
            loadScree.gameObject.SetActive(false);
            //读取数据
            SaveManager.Instance.LoadPlayerData();
            if (InventoryManager.Instance)
            {
                //InventoryManager.Instance.LoadData();
            }
            QuestManager.Instance.LoadQuestManager();
            yield break;
        }
        {
            player = GameManager.Instance.playerCharterstate.gameObject;
            //playerAgent = player.GetComponent<NavMeshAgent>();
            //playerAgent.enabled = false;
            player.transform.SetPositionAndRotation(GetDestion(destionTag).transform.position, GetDestion(destionTag).transform.rotation);
            //playerAgent.enabled = true;

            yield return null;
        }
    }
    private TranstionDestion GetDestion(TranstionDestion.DestionTag destionTag)
    {
        var entrans = FindObjectsOfType<TranstionDestion>();
        for (int i = 0; i < entrans.Length; i++)
        {
            if (entrans[i].destionTag == destionTag)
            {
                return entrans[i];
            }
        }
        return null;
    }
    IEnumerator LoadLevel(string sceneName)
    {
        //保存数据
        /*
        if (GameManager.Instance.playerCharterstate)
        {
            SaveManager.Instance.SavePlayerData();
        }
        if (InventoryManager.Instance)
        {
            InventoryManager.Instance.SaveData();
        }*/
        
        SceneFader fade = Instantiate(sceneFaderPrefab);
        if (sceneName != null)
        {

            //加载过度界面
            //yield return StartCoroutine(fade.FadeOut(fade.fadeOutDuratoion));
            yield return StartCoroutine(LoadScene(sceneName));

            //yield return SceneManager.LoadSceneAsync(sceneName);
            yield return player = Instantiate(playerPrefab, GameManager.Instance.GetEntrans().position, GameManager.Instance.GetEntrans().rotation);
            loadScree.gameObject.SetActive(false);
            //SaveManager.Instance.LoadPlayerData();
            /* if (InventoryManager.Instance)
             {
                 InventoryManager.Instance.LoadData();
             }*/
        }
        

            
        yield return StartCoroutine(fade.FadeIn(fade.fadeInDuration));
        yield break;
    }
    public void TranstionFirstLevel()
    {
        StartCoroutine(LoadLevel("Scene00"));
    }
    public void TransToLoadScene()
    {
        if (SaveManager.Instance.SceneName != "")
        {
            StartCoroutine(LoadLevel(SaveManager.Instance.SceneName));
        }
        else
        {
            TranstionFirstLevel();
        }
        
    }
    public void TranstionToMain()
    {
        StartCoroutine(LoadMain());
    }
    IEnumerator LoadMain()
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(fade.fadeOutDuratoion));
        yield return SceneManager.LoadSceneAsync("Main");
        yield return StartCoroutine(fade.FadeIn(fade.fadeInDuration));
        yield break;
    }

    public void EndNotyfi()
    {
        if (fadeFinshed)
        {
            StartCoroutine(LoadMain());
            fadeFinshed = false;
        }
        
    }
    
}
