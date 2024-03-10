using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private RectTransform _rectTransform = null;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private TextMeshProUGUI _cost;

    private Vector2 _originalPos = Vector2.zero;

    private CardState _cardState = null;
    private CardIdle _idle = null;
    private CardDrawn _drawn = null;
    private CardRecall _recall = null;
    private CardHovered _hovered = null;
    private CardSelected _selected = null;

    private Card _card = null;

    private void Awake()
    {
        _idle = new CardIdle(this);
        _drawn = new CardDrawn(this);
        _recall = new CardRecall(this);
        _hovered = new CardHovered(this);
        _selected = new CardSelected(this);
    }

    private void Update()
    {
        _cardState?.UpdateState();
    }

    public void SetDataValues(Card card)
    {
        _card = card;
        _image.sprite = card.Sprite;
        _title.text = card.Title;
        _description.text = card.Description;
        _cost.text = card.Cost.ToString();
    }

    public void ChangeState(ECardState cardState)
    {
        _cardState?.ExitState();

        switch (cardState)
        {
            case ECardState.IDLE:
                _cardState = _idle;
                break;
            case ECardState.DRAWN:
                _cardState = _drawn;
                break;
            case ECardState.RECALL:
                _cardState = _recall;
                break;
            case ECardState.HOVERED:
                _cardState = _hovered;
                break;
            case ECardState.SELECTED:
                _cardState = _selected;
                break;
        }

        _cardState?.EnterState();
    }

    public void OnPointerEnter(PointerEventData eventData) => _cardState?.OnPointerEnter();
    public void OnPointerExit(PointerEventData eventData) => _cardState?.OnPointerExit();
    public void OnPointerDown(PointerEventData eventData) => _cardState?.OnPointerDown(eventData);
    public void OnPointerUp(PointerEventData eventData) => _cardState?.OnPointerUp(eventData);

    public void SetOriginalPos(Vector2 pos) => _originalPos = pos;
    public RectTransform RectTransform => _rectTransform;
    public Vector2 OriginalPos => _originalPos;
    public Card Card => _card;
}
