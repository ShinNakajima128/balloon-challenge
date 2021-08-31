using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene�J�ڂ��Ǘ�����N���X
/// </summary>
public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
{
    [Header("�^�C�g����Scene")]
    [SerializeField] const string m_titleScene = "Title";
    [Header("�v���C����Scene")]
    [SerializeField] const string m_mainScene = "Main";
    [Header("���U���g��Scene")]
    [SerializeField] const string m_resultScene = "Result";
    [Header("���[�h���ɗv���鎞��")]
    [SerializeField] float m_LoadTimer = 1.0f;
    [Header("�t�F�[�h���Ɏg�p����Image")]
    [SerializeField] Image fadeImage;
    [Header("�t�F�[�h�̑��x")]
    [SerializeField] float fadeSpeedValue = 1.0f;
    [Header("�f�o�b�O�p")]
    [SerializeField] bool m_debugMode = false;
    /// <summary> ���݂�Scene </summary>
    string m_currentScene = "";
    /// <summary> �t�F�[�h�A�E�g�̃t���O </summary>
    public bool isFadeOut = false;
    /// <summary> �t�F�[�h�C���̃t���O </summary>
    public bool isFadeIn = false;
    /// <summary> �t�F�[�h������Image��RGBa </summary>
    float red, green, blue, alfa;
    /// <summary> Fade speed </summary>
    const float fadeSpeed = 0.01f;


    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        alfa = 1;
        SetAlfa();
    }

    void Start()
    {
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == m_titleScene)
        {
            Debug.Log("Title");
        }
        else if (SceneManager.GetActiveScene().name == m_mainScene)
        {
            Debug.Log("Main");
        }
        else if (SceneManager.GetActiveScene().name == m_resultScene)
        {
            Debug.Log("Result");
        }

        if (alfa > 0)
        {
            if (isFadeOut) isFadeOut = false;
            isFadeIn = true;
        }
    }

    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (alfa > 0)
        {
            if (isFadeOut) isFadeOut = false;
            isFadeIn = true;
        }

        m_currentScene = SceneManager.GetActiveScene().name;�@///���݂�Scene���X�V����

        switch (SceneManager.GetActiveScene().name)
        {
            case m_titleScene:
                Debug.Log("Title");
                break;
            case m_mainScene:
                Debug.Log("Main");
                break;
            case m_resultScene:
                Debug.Log("Result");
                break;
        }
    }

    private void LateUpdate()
    {
        ///�t�F�[�h�C��
        if (isFadeIn)
        {
            StartFadeIn();///�t�F�[�h�C���J�n
        }

        ///�t�F�[�h�A�E�g
        if (isFadeOut)
        {
            StartFadeOut();�@///�t�F�[�h�A�E�g�J�n
        }

        if (m_debugMode)
        {

        }
    }

   
    /// <summary> �^�C�g���֑J�ڂ��� </summary>
    public void LoadTitleScene()
    {
        Time.timeScale = 1f;
        isFadeOut = true;
        StartCoroutine(LoadScene(m_titleScene, m_LoadTimer));
    }

    /// <summary> �Q�[���V�[���֑J�ڂ��� </summary>
    public void LoadMainScene()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_mainScene, m_LoadTimer));
    }

    /// <summary> ���U���g�֑J�ڂ��� </summary>
    public void LoadResultScene()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_resultScene, m_LoadTimer));
    }

    /// <summary> �C�ӂ�Scene�֑J�ڂ��� </summary>
    public void AnyLoadScene(string loadScene)
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(loadScene, m_LoadTimer));
    }

    /// <summary>
    /// Scene�̃��X�^�[�g
    /// </summary>
    public void Restart()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_currentScene, m_LoadTimer));
    }

    /// <summary>
    /// �N���W�b�g�֑J�ڂ���
    /// </summary>
    public void LoadCredit()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene("Credit", m_LoadTimer));
    }

    /// <summary>
    /// �Q�[�����I������
    /// </summary>
    public void QuitGame()
    {
        isFadeOut = true;
        StartCoroutine(QuitScene(m_LoadTimer));
    }

    /// <summary>
    /// �t�F�[�h�A�E�g���J�n����
    /// </summary>
    void StartFadeOut()
    {
        alfa += fadeSpeedValue * fadeSpeed;
        SetAlfa();

        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    /// <summary>
    /// �t�F�[�h�C�����J�n����
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeedValue * fadeSpeed;
        SetAlfa();

        if (alfa <= 0)
        {
            isFadeIn = false;
        }
    }

    void OffPanel()
    {
        isFadeIn = true;
    }

    void OnPanel()
    {
        isFadeOut = true;
    }
    /// <summary>
    /// �A���t�@�l��Image�ɃZ�b�g����
    /// </summary>
    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    IEnumerator LoadScene(string name, float timer)
    {
        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(name);
    }

    IEnumerator QuitScene(float timer)
    {
        yield return new WaitForSeconds(timer);

        Application.Quit();
    }
}
