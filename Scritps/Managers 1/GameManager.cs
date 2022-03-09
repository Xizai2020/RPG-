using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public CinemachineVirtualCamera freeLook;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public CharacterStates playerCharterstate;
    private List<IEngGameServer> endGameServers = new List<IEngGameServer>();
    public void RigisterPlayer(CharacterStates player)
    {
        playerCharterstate = player;
        freeLook = FindObjectOfType<CinemachineVirtualCamera>();
        if (freeLook != null)
        {
            freeLook.Follow = playerCharterstate.transform;
            freeLook.LookAt = playerCharterstate.transform;
        }
    }
    public void AddObserver(IEngGameServer observer)
    {
        endGameServers.Add(observer);
    }
    public void RemoveObserver(IEngGameServer observer)
    {
        endGameServers.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach(var observer in endGameServers)
        {
            observer.EndNotyfi();
        }
    }
    public Transform GetEntrans()
    {
        foreach (var item in FindObjectsOfType<TranstionDestion>())
        {
            if (item.destionTag == TranstionDestion.DestionTag.Enter)
            {
                return item.transform;
            }
        }
        return null;
    }
}
