using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGaugeManager : MonoBehaviour
{
    // GaugePatternの子オブジェクトを格納する配列
    [SerializeField] GameObject[] gaugePattern = new GameObject[5];
    [SerializeField] float m_skillSpeed = 3f;
    int patternNumber = 0;

    public static bool IsEfect = false;
    public static SkillGaugeManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void SetGaugePattern()
    {
        patternNumber = Random.Range(0, 5);
        gaugePattern[patternNumber].SetActive(true);
    }
    public void RemoveGaugePattern()
    {
        gaugePattern[patternNumber].SetActive(false);
    }
    public void JudgeGaugePattern(float value)
    {
        float judgeNumber = (float)1 / gaugePattern.Length;
        int judgePatternNumber = (int)(value / judgeNumber);
        if (judgePatternNumber == patternNumber)
        {
            IsEfect = true;
        }
        else
        {
            IsEfect = false;
        } 


    }
    public float SkillSpeed(bool frag)
    {
        if (frag)
        {
            return m_skillSpeed;
        }
        else
        {
            return 1f;
        }
    }
}