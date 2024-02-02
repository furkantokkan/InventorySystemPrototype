using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Add This;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public static GameObject draggedItem;
    public ItemType itemType;
    public int ItemNumber;

    Vector3 startPosition;

    Transform startParent; //this is the orginal slot the item was inside of

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemSlot.slotItemNumber = ItemNumber;
        draggedItem = this.gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //we need to stop the interaction with other objects
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; //Input.mousePosition;
        GetComponent<Canvas>().sortingOrder = 2;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        draggedItem = null;

        //put back the interaction with other objects
        GetComponent<Canvas>().sortingOrder = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }

}
