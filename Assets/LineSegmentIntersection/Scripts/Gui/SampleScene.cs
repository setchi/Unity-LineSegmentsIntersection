using UnityEngine;
using UnityEngine.UI;

namespace LineSegmentsIntersection
{
    public class SampleScene : MonoBehaviour
    {
        [SerializeField] LineSegment lineSegmentA = default;
        [SerializeField] LineSegment lineSegmentB = default;
        [SerializeField] Image imageIntersection = default;

        void Start()
        {
            UpdateIntersection();
            lineSegmentA.OnDrag(UpdateIntersection);
            lineSegmentB.OnDrag(UpdateIntersection);
        }

        void UpdateIntersection()
        {
            var p1 = lineSegmentA.PointA;
            var p2 = lineSegmentA.PointB;
            var p3 = lineSegmentB.PointA;
            var p4 = lineSegmentB.PointB;

            if (Math2d.LineSegmentsIntersection(p1, p2, p3, p4, out var intersection))
            {
                imageIntersection.color = Color.red;
                imageIntersection.rectTransform.anchoredPosition = intersection;
                lineSegmentA.SetColor(Color.green);
                lineSegmentB.SetColor(Color.green);
            }
            else
            {
                imageIntersection.color = Color.clear;
                lineSegmentA.SetColor(Color.gray);
                lineSegmentB.SetColor(Color.gray);
            }
        }
    }
}
