using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]private Image itemImage;
    private bool isDragging = false;
    public ItemDetails currentItem
    {
        get;
        private set;
    }

    private bool isSelected;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    private Vector3 initialPosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public void SetEmpty()
    {
        gameObject.SetActive(false);
        Debug.Log("SlotUIsetEmpty");
    }
    
    public void Initialize(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        itemImage.sprite = itemDetails.itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        if (!isDragging)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            initialPosition = rectTransform.position;
            isDragging = true;
        }
        else
        {
            initialPosition = rectTransform.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag" + currentItem.itemName);
        if (isDragging)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
            transform.localPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (isDragging)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            LeanTween.move(gameObject, initialPosition, 0.7f).setEase(LeanTweenType.easeOutExpo);
            isDragging = false;
        }
    }
}
