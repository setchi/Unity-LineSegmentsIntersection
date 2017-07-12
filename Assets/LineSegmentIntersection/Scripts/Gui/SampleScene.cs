using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LineSegmentsIntersection
{
    public class SampleScene : MonoBehaviour
    {
        [SerializeField]
        LineSegment lineSegmentA;
        [SerializeField]
        LineSegment lineSegmentB;
        [SerializeField]
        Image imageIntersection;

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

            Vector2 intersection;
            if (Math2d.LineSegmentsIntersection(p1, p2, p3, p4, out intersection))
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
