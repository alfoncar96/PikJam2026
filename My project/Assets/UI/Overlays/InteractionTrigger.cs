using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponentInParent<Interactable>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        InteractionManager.Instance.ShowPopup(interactable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        InteractionManager.Instance.HidePopup();
    }
}