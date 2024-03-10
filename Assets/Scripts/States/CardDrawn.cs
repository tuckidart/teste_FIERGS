using UnityEngine.EventSystems;
using UnityEngine;

public class CardDrawn : CardState
{
    private readonly float _animationTime = 0.1f;
    private float _elapsedLerp = 0.0f;

    public CardDrawn(CardView view)
    {
        _view = view;
        _rectTransform = _view.RectTransform;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        _elapsedLerp += Time.deltaTime / _animationTime;

        Vector3 bufferTransform = _rectTransform.anchoredPosition;

        bufferTransform = Vector2.Lerp(Vector2.zero, _view.OriginalPos, _elapsedLerp);
        _rectTransform.anchoredPosition = bufferTransform;

        bufferTransform = Vector3.Lerp(Vector3.zero, Vector3.one, _elapsedLerp);
        _rectTransform.localScale = bufferTransform;

        if (_elapsedLerp >= 1.0f)
        {
            _view.ChangeState(ECardState.IDLE);
        }
    }

    public override void ExitState() { }

    public override void OnPointerEnter() { }
    public override void OnPointerExit() { }
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData) { }
}