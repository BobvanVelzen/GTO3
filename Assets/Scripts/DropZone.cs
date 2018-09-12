using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public int limit = 1;
    public CardType cardType;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable card = eventData.pointerDrag.GetComponent<Draggable>();
        if (card != null &&
            (transform.childCount < limit || limit < 0) &&
            (card.type == cardType || cardType == CardType.NONE))
        {
            card.parentReturn = transform;
        }
    }
}
