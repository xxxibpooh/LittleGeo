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


    //ж�س���
    private void OnBeforeSceneUnloadEvent()
    {
       //����item�Ƿ�ʰȡ
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);
            }
        }
        //����ɽ�����Ʒ�Ƿ�ʰȡ
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

    //���س���
    private void OnAfterSceneLoadedEvent()
    {
        //ѭ����������������
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);//true�����ڵ�ǰ����ʾ��
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
        //ֻ��ʰȡ����Ʒ֮���ֵ��ﴢ���boolֵ���false
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.itemName] = false;
        }
    }
}
