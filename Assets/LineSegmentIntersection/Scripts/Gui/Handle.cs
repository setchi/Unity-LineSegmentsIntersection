using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace LineSegmentsIntersection
{
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public class Handle : MonoBehaviour, IDragHandler
    {
        Image image;
        RectTransform rectTransform;
        Action<Vector2> onDrag;

        public Vector2 Position => rectTransform.anchoredPosition;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public void SetPosition(Vector2 position)
        {
            rectTransform.anchoredPosition3D = position;
        }

        public void OnDrag(Action<Vector2> callback)
        {
            onDrag = callback;
        }

        public void SetColor(Color color)
        {
            image.color = color;
        }

        void IDragHandler.OnDrag(PointerEventData e)
        {
            e.Use();

            onDrag?.Invoke(e.position);
        }
    }
}
