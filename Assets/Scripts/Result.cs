using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]private Text m_text;
    public string m_name = null;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
    public void ResultDisPlay()
    {
        this.gameObject.SetActive(true);
        m_text.text = m_name + " " + "Lose";
    }
}
