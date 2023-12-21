using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotebookPage
{
    [Header("PageœÍ«È")]
    public Sprite ImageLeft;
    public Sprite ImageRight;

    [TextArea]
    public string Title;
    [TextArea]
    public string ContentLeft;
    [TextArea]
    public string ContentRight;
}
