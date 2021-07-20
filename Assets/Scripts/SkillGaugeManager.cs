using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGaugeManager : MonoBehaviour
{
    // GaugePatternの子オブジェクトを格納する配列
    [SerializeField] GameObject[] gaugePatternList = default;
    int patternNumber = 0;

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGaugePattern()
    {
        patternNumber = Random.Range(0, 5);
        gaugePatternList[patternNumber].SetActive(true);
    }
    public void RemoveGaugePattern()
    {
        gaugePatternList[patternNumber].SetActive(false);
    }
    public void JudgeGaugePattern(float value)
    {
        float judgeNumber = 1 / gaugePatternList.Length;
        int judgePatternNumber = (int)(value / judgeNumber);



    }
}