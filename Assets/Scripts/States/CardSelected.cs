using UnityEngine.EventSystems;
using UnityEngine;

public class CardSelected : CardState
{
    public CardSelected(CardView view)
    {
        _view = view;
        _rectTransform = _view.RectTransform;
    }

    public override void EnterState()
    {
        AudioManager.Instance.PlayCardSelect();
    }

    public override void UpdateState()
    {
        _view.RectTransform.position = Input.mousePosition;
    }

    public override void ExitState() { }
    public override void OnPointerEnter() { }
    public override void OnPointerExit() { }
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            _view.ChangeState(ECardState.RECALL);
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            BattleMaestro.Instance.PlayCard(_view);
        }
    }
}