using System.Collections;   // コルーチンを使うため
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// パワーゲージを制御するコンポーネント
/// 適当なオブジェクトにアタッチして使う。
/// </summary>
public class PowerGaugeController : MonoBehaviour
{
    /// <summary>ゲーム マネージャー</summary>
    [SerializeField] GameManager m_gm = default;
    /// <summary>パワーゲージとなる Slider</summary>
    [SerializeField] Slider m_powerGauge = default;
    /// <summary>ゲージが上下する速度</summary>
    [SerializeField] float m_gaugeSpeed = 3;
    /// <summary>プレイヤーの持ち時間</summary>
    [SerializeField] float m_timeLimit = 10;
    [SerializeField] Text m_timeText;
    Coroutine m_coroutine = default;
    
    /// <summary>
    /// ゲージを動かす／止める時に呼ぶ。
    /// ゲージが動いていない時に呼ばれたら、ゲージを動かす。
    /// ゲージが動いている時に呼ばれたら、ゲージを止めて空気を送り込む。
    /// 空気を送り込む量は Slider.value になるため、送り込む量を調節したい場合は Slider の Min Value/Max Value で調整する。
    /// </summary>
    public void StartAndStopGauge()
    {
        if (m_coroutine == null)
        {
            m_timeText.gameObject.SetActive(true);
            m_coroutine = StartCoroutine(PingPongGauge());
        }
        else
        {
            m_timeText.gameObject.SetActive(false);
            StopCoroutine(m_coroutine);
            m_coroutine = null;
            Debug.Log($"Pump value: {m_powerGauge.value}");
            SkillGaugeManager.Instance.JudgeGaugePattern(m_powerGauge.value);
            m_gm.Pump(m_powerGauge.value);
        }
    }

    /// <summary>
    /// ゲージを上下させる。
    /// </summary>
    /// <returns></returns>
    IEnumerator PingPongGauge()
    {
        float timer = 0;
        float speed = SkillGaugeManager.Instance.SkillSpeed(SkillGaugeManager.IsEfect);

        while (true)
        {
            m_powerGauge.value = Mathf.PingPong(m_gaugeSpeed * speed * timer, m_powerGauge.maxValue);
            timer += Time.deltaTime;
            m_timeText.text = "残り : " + (int)(m_timeLimit - timer);
            if (timer > m_timeLimit)
            {
                StartAndStopGauge();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
