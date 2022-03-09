using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeanUI : MonoBehaviour
{
    public Button startGameBtn;
    private Button contineGameBtn;
    private Button quitGameBtn;

   // private PlayableDirector playableDirector;
    private void Awake()
    {
        startGameBtn = transform.GetChild(1).GetComponent<Button>();
        contineGameBtn = transform.GetChild(2).GetComponent<Button>();
        quitGameBtn = transform.GetChild(3).GetComponent<Button>();
        //  playableDirector = FindObjectOfType<PlayableDirector>();
        //  playableDirector.stopped += NewGame;
        //   startGameBtn.onClick.AddListener(PlayTimeLine);
        startGameBtn.onClick.AddListener(NewGame);
        contineGameBtn.onClick.AddListener(ContineGame);
        quitGameBtn.onClick.AddListener(QuitGame);
    }
    /*
    void  PlayTimeLine()
    {
        playableDirector.Play();
    }*/
    void NewGame()
    {
        SceneCtroll.Instance.TransToLoadScene();
        //ת����������ȡ����
       // PlayerPrefs.DeleteAll();
       // SceneCtroll.Instance.TranstionFirstLevel();
        //ת������
    }
    void ContineGame()
    {
        PlayerPrefs.DeleteAll();
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
