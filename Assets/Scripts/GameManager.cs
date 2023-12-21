using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<bool> puzzleCompletedList = new List<bool>();
    private int totalPuzzles = 5;

    public Animator endAnimator;

    private void Awake()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
    }
    private void Start()
    {
        InitializePuzzleList();

        EventHandler.SmokeExtinguishInteractiveEvent += EventHandler_SmokeExtinguishInteractiveEvent;
        EventHandler.SignInteractiveEvent += EventHandler_SignInteractiveEvent;
        EventHandler.CrowInteractiveEvent += EventHandler_CrowInteractiveEvent;
        EventHandler.CharaterFarmInteractiveEvent += EventHandler_CharaterFarmInteractiveEvent;
        EventHandler.TouristInteractiveEvent += EventHandler_TouristInteractiveEvent;
    }


    private void InitializePuzzleList()
    {
        // ��ʼ�������б���ʾÿ����������״̬��Ĭ�϶�Ϊfalse
        for (int i = 0; i < totalPuzzles; i++)
        {
            puzzleCompletedList.Add(false);
        }
    }

    private void SetPuzzleCompleted(int puzzleIndex)
    {
        // ���ö�Ӧ��������״̬Ϊtrue
        puzzleCompletedList[puzzleIndex] = true;

        // ����Ƿ��������ⶼ�����
        if (puzzleCompletedList.TrueForAll(puzzle => puzzle))
        {
            // �������ⶼ����ˣ�������Ϸ���
            GameCompleted();
        }
    }

    private void EventHandler_TouristInteractiveEvent(ItemName obj)
    {
        SetPuzzleCompleted(0);
    }
    private void EventHandler_CharaterFarmInteractiveEvent(ItemName obj)
    {
        SetPuzzleCompleted(1);
    }

    private void EventHandler_CrowInteractiveEvent(ItemName name)
    {
        SetPuzzleCompleted(2);
    }

    private void EventHandler_SignInteractiveEvent(ItemName name)
    {
        SetPuzzleCompleted(3);
    }

    private void EventHandler_SmokeExtinguishInteractiveEvent(ItemName name)
    {
        SetPuzzleCompleted(4);
    }


    private void GameCompleted()
    {
        Debug.Log("��Ϸ���");
        EventHandler.CallGameStateChangeEvent(GameState.Pause);
        endAnimator.SetBool("IsEnd", true);
    }
}
