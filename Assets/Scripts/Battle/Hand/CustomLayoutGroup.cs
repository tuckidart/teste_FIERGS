using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CustomLayoutGroup : MonoBehaviour
{
    private List<CardView> _cards = null;

    private RectTransform _myTransform = null;

    [Space]

    [SerializeField]
    private float _spacing = 0.0f;

    private void OnValidate()
    {
        if (_myTransform == null)
        {
            _myTransform = GetComponent<RectTransform>();
            _cards = new List<CardView>();
        }
    }

    public void AddChild(CardView card)
    {
        _cards.Add(card);
        UpdateLayout();
    }

    public void RemoveChild(CardView card)
    {
        _cards.Remove(card);
        UpdateLayout();
    }

    public GameObject GetInactiveChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (!child.activeSelf)
            {
                return child;
            }
        }

        return null;
    }

    public void UpdateLayout()
    {
        int activeCount = 0;

        foreach (CardView child in _cards)
        {
            if (child.gameObject.activeSelf)
            {
                activeCount++;
            }
        }

        bool isEven = activeCount % 2 == 0;

        Vector2 position = Vector2.zero;
        position.x -= _spacing * (activeCount / 2);

        if (isEven)
        {
            position.x += _spacing / 2.0f;
        }

        foreach (CardView card in _cards)
        {
            if (card.gameObject.activeSelf)
            {
                card.RectTransform.anchoredPosition = position;
                card.SetOriginalPos(position);
                position.x += _spacing;
            }
        }
    }
}
