using UnityEngine.EventSystems;
using UnityEngine;

public class CardRecall : CardState
{
    private Vector2 _startingPos = Vector2.zero;
    private Vector3 _startScale = Vector3.forward;

    private readonly float _animationTime = 0.1f;
    private float _elapsedLerp = 0.0f;

    public CardRecall(CardView view)
    {
        _view = view;
        _rectTransform = _view.RectTransform;
    }

    public override void EnterState()
    {
        _startingPos = _rectTransform.anchoredPosition;
        _startScale = _rectTransform.localScale;
    }

    public override void UpdateState()
    {
        _elapsedLerp += Time.deltaTime / _animationTime;

        Vector3 bufferTransform = _rectTransform.anchoredPosition;

        bufferTransform = Vector2.Lerp(_startingPos, _view.OriginalPos, _elapsedLerp);
        _rectTransform.anchoredPosition = bufferTransform;

        bufferTransform = Vector3.Lerp(_startScale, Vector3.one, _elapsedLerp);
        _rectTransform.localScale = bufferTransform;

        if (_elapsedLerp >= 1.0f)
        {
            _view.ChangeState(ECardState.IDLE);
        }
    }

    public override void ExitState()
    {
        _elapsedLerp = 0.0f;
    }

    public override void OnPointerEnter() { }
    public override void OnPointerExit() { }
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData) { }
}