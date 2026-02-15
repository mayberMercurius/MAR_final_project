using UnityEngine;

public class TargetReachFeedback : MonoBehaviour
{
    [Header("References")]
    public Transform tip;
    public Transform[] targets;
    public Material[] targetMaterials;
    public LineRenderer[] lines;
    public AudioSource audioSource;

    [Header("Settings")]
    public float reachDistance = 0.05f;

    private bool[] reached;

    void Start()
    {
        reached = new bool[targets.Length];
    }

    void Update()
    {
        if (tip == null) return;

        for (int i = 0; i < targets.Length; i++)
        {
            if (reached[i]) continue;
            if (targets[i] == null) continue;

            float d = Vector3.Distance(tip.position, targets[i].position);

            if (d < reachDistance)
            {
                reached[i] = true;

                if (targetMaterials[i] != null)
                    targetMaterials[i].color = Color.yellow;

                if (lines[i] != null)
                    lines[i].enabled = false;

                if (audioSource != null)
                    audioSource.Play();

                Debug.Log("Target " + (i + 1) + " reached");
            }
        }
    }
}
