using UnityEngine;
using System;

namespace LineSegmentsIntersection
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineSegment : MonoBehaviour
    {
        [SerializeField] Handle handleA = default;
        [SerializeField] Handle handleB = default;

        LineRenderer lineRenderer;
        Action onDrag;

        public Vector2 PointA => handleA.Position;
        public Vector2 PointB => handleB.Position;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            UpdateLine();

            handleA.OnDrag(position =>
            {
                handleA.SetPosition(position);
                UpdateLine();
                onDrag?.Invoke();
            });

            handleB.OnDrag(position =>
            {
                handleB.SetPosition(position);
                UpdateLine();
                onDrag?.Invoke();
            });
        }

        void UpdateLine()
        {
            lineRenderer.SetPosition(0, PointA);
            lineRenderer.SetPosition(1, PointB);
        }

        public void OnDrag(Action callback)
        {
            onDrag = callback;
        }

        public void SetColor(Color color)
        {
            handleA.SetColor(color);
            handleB.SetColor(color);
        }
    }
}
