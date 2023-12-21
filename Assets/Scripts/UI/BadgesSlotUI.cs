using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgesSlotUI : MonoBehaviour
{
    [SerializeField] private Image badgeImage;
    private void Start()
    {
        //badgeImage = GetComponent<Image>();
    }
    public void SetImage(Sprite m_badgeImage)
    {
        badgeImage.sprite = m_badgeImage;
    }
}
