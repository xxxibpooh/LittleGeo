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
        // 初始化布尔列表，表示每个谜题的完成状态，默认都为false
        for (int i = 0; i < totalPuzzles; i++)
        {
            puzzleCompletedList.Add(false);
        }
    }

    private void SetPuzzleCompleted(int puzzleIndex)
    {
        // 设置对应谜题的完成状态为true
        puzzleCompletedList[puzzleIndex] = true;

        // 检查是否所有谜题都已完成
        if (puzzleCompletedList.TrueForAll(puzzle => puzzle))
        {
            // 所有谜题都完成了，触发游戏结局
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
        Debug.Log("游戏完成");
        EventHandler.CallGameStateChangeEvent(GameState.Pause);
        endAnimator.SetBool("IsEnd", true);
    }
}
