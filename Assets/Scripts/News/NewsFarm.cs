using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsFarm : MonoBehaviour
{
   private void Awake()
    {
        EventHandler.CallFarmSceneUnlock();
    }
}
