using UnityEngine.EventSystems;
using UnityEngine;

public enum ECardState
{
    IDLE,
    HOVERED,
    SELECTED,
    RECALL,
    PLAYED,
    DRAWN,
    DISCARD
}

public abstract class CardState
{
    protected RectTransform _rectTransform = null;
    protected CardView _view = null;

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public abstract void OnPointerEnter();
    public abstract void OnPointerExit();
    public abstract void OnPointerUp(PointerEventData eventData);
    public abstract void OnPointerDown(PointerEventData eventData);
}
