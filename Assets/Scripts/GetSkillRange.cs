using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillRange : MonoBehaviour
{
    float minValue;
    float maxValue;
    public float MinValue
    { get { return minValue; } set { minValue = value; }
    }

    public float MaxValue
    { 
        get { return maxValue; } set { maxValue = value; }
    }
}
