using UnityEngine;

public class VisibilityByVision : MonoBehaviour
{
    SpriteRenderer sr;
    PlayerVision vision;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        vision = Object.FindFirstObjectByType<PlayerVision>();
    }

    void Update()
    {
        bool visible = vision.CanSee(transform.position);
        sr.enabled = visible;
    }
}