﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTurn : MonoBehaviour
{
    public static CurrentTurn Instance = default;
    [SerializeField] GameObject m_icon = default;
    [SerializeField] List<GameObject> playerList = new List<GameObject>();

    public GameObject Icon
    {
        get => m_icon;
        set { m_icon = value; }
    }

    public List<GameObject> PlayerList
    {
        get => playerList;
        set { playerList = value; }
    }

    private void Awake()
    {
        Instance = this;
        m_icon.SetActive(false);
    }

    public void OnIcon(int playerNum)
    {
        m_icon.SetActive(true);
        m_icon.transform.position = playerList[playerNum].transform.position;
    }
}