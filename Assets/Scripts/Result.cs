using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]private Text m_text;
    public string m_name = null;
    [SerializeField] GameObject m_buttons;
    void Start()
    {
        this.gameObject.SetActive(false);
        m_buttons.SetActive(false);
    }

    void Update()
    {
        
    }
    public void ResultDisPlay()
    {
        this.gameObject.SetActive(true);
        m_text.text = m_name + " " + "Lose";
        StartCoroutine(FinishUI());
    }

    IEnumerator FinishUI()
    {
        yield return new WaitForSeconds(3f);
        m_buttons.SetActive(true);
    }
}
