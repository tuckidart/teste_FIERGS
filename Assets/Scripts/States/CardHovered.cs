using UnityEngine.EventSystems;
using UnityEngine;

public class CardHovered : CardState
{
    private Vector3 _startScale = Vector3.forward;
    private Vector2 _startingPos = Vector2.zero;

    private readonly float _animationTime = 0.1f;
    private readonly float _zoomedScale = 1.2f;
    private readonly float _zoomedPosY = 250.0f;
    private float _elapsedLerp = 0.0f;
    private bool _animating = false;

    public CardHovered(CardView view)
    {
        _view = view;
        _rectTransform = _view.RectTransform;
    }

    public override void EnterState()
    {
        _startingPos = _rectTransform.anchoredPosition;
        _startScale = _rectTransform.localScale;

        AudioManager.Instance.PlayCardHover();

        _animating = true;
    }

    public override void UpdateState()
    {
        if (_animating)
        {
            Vector3 bufferTransform = _rectTransform.anchoredPosition;

            _elapsedLerp += Time.deltaTime / _animationTime;

            bufferTransform.y = Mathf.Lerp(_startingPos.y, _zoomedPosY, _elapsedLerp);
            _rectTransform.anchoredPosition = bufferTransform;

            bufferTransform.x = Mathf.Lerp(_startScale.y, _zoomedScale, _elapsedLerp);
            bufferTransform.y = bufferTransform.x;
            bufferTransform.z = bufferTransform.x;
            _rectTransform.localScale = bufferTransform;

            if (_elapsedLerp >= 1.0f)
            {
                _animating = false;
            }
        }
    }

    public override void ExitState()
    {
        _elapsedLerp = 0.0f;
        _animating = false;
    }

    public override void OnPointerEnter() { }
    public override void OnPointerExit() => _view.ChangeState(ECardState.RECALL);
    public override void OnPointerUp(PointerEventData eventData) { }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _view.ChangeState(ECardState.SELECTED);
        }
    }
}