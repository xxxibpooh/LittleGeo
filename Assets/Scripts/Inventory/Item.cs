using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        //添加到背包当中
        InventoryManager.Instance.AddItem(itemName);
        this.gameObject.SetActive(false);
    }
}
