﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ここへエフェクトの種類を追加する
public enum EffectType
{
    /// <summary>
    /// 使用しない
    /// </summary>
    None,
}

public class EffectManager : SingletonMonoBehaviour<EffectManager>
{
    /// オブジェクトのデータをファイルに保存する
    [System.Serializable]
    class EffectData
    {
        /// <summary> EffectのPrefab </summary>
        public GameObject EffectPrefab = default;
        /// <summary> 最大表示数 </summary>
        public int MaxCount = 1;
    }

    [SerializeField] EffectData[] m_effectDatas = default;
    Dictionary<EffectType, List<EffectControl>> m_effectDic = new Dictionary<EffectType, List<EffectControl>>();

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < m_effectDatas.Length; i++)
        {
            EffectType effectType = (EffectType)(i + 1);
            m_effectDic.Add(effectType, new List<EffectControl>());
            for (int k = 0; k < m_effectDatas[i].MaxCount; k++)
            {
                var instance = Instantiate(m_effectDatas[i].EffectPrefab, this.transform);
                var eControl = instance.AddComponent<EffectControl>();
                m_effectDic[effectType].Add(eControl);
            }
        }
    }

    public static void PlayEffect(EffectType effectType, Vector3 pos)
    {
        foreach (var effect in Instance.m_effectDic[effectType])
        {
            if (effect.IsActive())
            {
                continue;
            }
            effect.Play(pos);
            return;
        }
    }
}
