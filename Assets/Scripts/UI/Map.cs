using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject player;
    public Transform museumPosition;
    public Transform lakePosition;
    public Transform farmPosition;
    public Transform mountainPosition;
    public Transform campingsitePosition;

    private string currentScene;
    private void Awake()
    {
        currentScene = TransitionManager.Instance.GetCurrentScene();
        if (currentScene == "Museum")
            player.GetComponent<RectTransform>().position = museumPosition.position;
        if (currentScene == "Lake")
            player.GetComponent<RectTransform>().position = lakePosition.position;
        if (currentScene == "Mountain")
            player.GetComponent<RectTransform>().position = mountainPosition.position;
        if (currentScene == "Farm")
            player.GetComponent<RectTransform>().position = farmPosition.position;
        if (currentScene == "CampingSite")
            player.GetComponent<RectTransform>().position = campingsitePosition.position;
    }

    public void TeleportMuseum()
    {
        TransitionManager.Instance.Transition("Map", "Museum");
    }

    public void TeleportCampingSite()
    {
        TransitionManager.Instance.Transition("Map", "CampingSite");
    }
    public void TeleportMountain()
    {
        TransitionManager.Instance.Transition("Map", "Mountain");
    }
    public void TeleportLake()
    {
        TransitionManager.Instance.Transition("Map", "Lake");
    }
    public void TeleportFarm()
    {
        TransitionManager.Instance.Transition("Map", "Farm");
    }
    public void TeleportClose()
    {
        TransitionManager.Instance.Transition("Map", currentScene);
    }
}
