using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] InputField inputField = default;
    [SerializeField] string m_playerName = default;
    [SerializeField] GameObject m_inputPanel = default;
    [SerializeField] GameObject m_playerList = default;

    public string GetPlayerName
    {
        get { return m_playerName; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (PhotonNetwork.IsConnected)
        {
            m_inputPanel.SetActive(false);
            m_playerList.SetActive(true);
        }
    }

    public void SetNickName()
    {
        m_playerName = inputField.text;
        NetworkManager.isInputed = true;
        Debug.Log(m_playerName);
    }
}
