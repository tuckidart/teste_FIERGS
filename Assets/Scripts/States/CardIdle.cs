using UnityEngine.EventSystems;

public class CardIdle : CardState
{
    public CardIdle(CardView view)
    {
        _view = view;
    }

    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }

    public override void OnPointerEnter()
    {
        if (BattleMaestro.Instance.CanPlay)
        {
            _view.ChangeState(ECardState.HOVERED);
        }
    }
    public override void OnPointerExit() { }
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData) { }
}