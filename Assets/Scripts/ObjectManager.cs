using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemAvailableDict = new Dictionary<ItemName, bool>();
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();

   

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.AddItemSlotEvent += OnAddItemSlotEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }


    //卸载场景
    private void OnBeforeSceneUnloadEvent()
    {
       //保存item是否被拾取
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);
            }
        }
        //保存可交互物品是否被拾取
        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
            {
                interactiveStateDict[item.name] = item.isDone;
            }
            else
            {
                interactiveStateDict.Add(item.name, item.isDone);
            }
        }

/*        foreach (var item in FindObjectsOfType<Smoke>())
        {
            if (smokeHeavyStateDict.ContainsKey(item.name))
            {
                smokeHeavyStateDict[item.name] = item.isHeavy;
            }
            else
            {
                smokeHeavyStateDict.Add(item.name, item.isHeavy);
            }
        }*/
    }

    //加载场景
    private void OnAfterSceneLoadedEvent()
    {
        //循环场景里所有物体
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);//true代表在当前是显示的
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);
            }
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
            {
                item.isDone=interactiveStateDict[item.name];
            }
            else
            {
                interactiveStateDict.Add(item.name, item.isDone);
            }
        }

/*        foreach (var item in FindObjectsOfType<Smoke>())
        {
            if (smokeHeavyStateDict.ContainsKey(item.name))
            {
                item.isDone = smokeHeavyStateDict[item.name];
            }
            else
            {
                smokeHeavyStateDict.Add(item.name, item.isHeavy);
            }
        }*/
    }

    private void OnAddItemSlotEvent(ItemDetails itemDetails)
    {
        //只在拾取了物品之后，字典里储存的bool值变成false
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.itemName] = false;
        }
    }
}
