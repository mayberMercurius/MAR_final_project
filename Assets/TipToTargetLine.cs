using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TipToTargetLine : MonoBehaviour
{
    public Transform tip;
    public Transform target;

    [Header("Appearance")]
    public float width = 0.01f;

    private LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.alignment = LineAlignment.View;
        lr.useWorldSpace = true;

        // Force constant thickness (works across Unity versions)
        lr.startWidth = width;
        lr.endWidth = width;
    }

    void Update()
    {
        if (tip == null || target == null) return;

        lr.SetPosition(0, tip.position);
        lr.SetPosition(1, target.position);

        // keep width consistent even if you tweak 'width' live
        lr.startWidth = width;
        lr.endWidth = width;
    }
}
