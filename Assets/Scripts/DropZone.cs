﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData)
    {
        Draggable card = eventData.pointerDrag.GetComponent<Draggable>();
        if (card != null)
        {
            card.parentReturn = transform;
        }
    }
}
