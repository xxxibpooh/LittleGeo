using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public string startScene;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;
    private bool canTransition;

    private string currentScene;

    private void OnEnable()
    {
        EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
    }

    private void OnGameStateChangeEvent(GameState gameState)
    {
        canTransition = gameState == GameState.GamePlay;
    }

/*    private void Start()
    {
        canTransition = true;//��ʱ��ôд
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }*/
    public void StartGameTransition()
    {
        canTransition = true;//��ʱ��ôд
        StartCoroutine(TransitionToScene("Menu", startScene));
    }

    public void Transition(string from, string to)
    {
        if (!isFade && canTransition)
        {
            StartCoroutine(TransitionToScene(from, to));
        }

    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        currentScene = from;
        yield return Fade(1);
        if (from != string.Empty)//��ʼ��������
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }
        //�첽ж�ء��첽����
        //loadҪ���ģʽ��addtive�Ż�ѳ������ص�������
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        //�����³���Ϊ�����
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        EventHandler.CallAfterSceneLoadedEvent();
        yield return Fade(0);

    }

    //targetAlpha 1�Ǻ�ɫ��0��͸��
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }

    public string GetCurrentScene()
    {
        return currentScene;
    }
}
