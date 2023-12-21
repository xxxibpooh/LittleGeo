using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotebookData_SO", menuName = "Notebook/NotebookData_SO")]
public class NotebookData_SO : ScriptableObject
{
    public string title;
    public string contentLeft;
    public string contentRight;
    public Sprite pictureLeft;
    public Sprite pictureRight;
}
