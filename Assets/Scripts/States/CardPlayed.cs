using UnityEngine.EventSystems;
using UnityEngine;

public class CardPlayed : CardState
{
    public CardPlayed(CardView view)
    {
        _view = view;
        _rectTransform = _view.RectTransform;
    }

    public override void EnterState() { }

    public override void UpdateState()
    {

    }

    public override void ExitState() { }
    public override void OnPointerEnter() { }
    public override void OnPointerExit() { }
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData) { }
}