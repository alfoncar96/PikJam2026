using UnityEngine;
using UnityEngine.UI;

public class InteractionPopup : MonoBehaviour
{
    public Button examineBtn;
    public Button pickUpBtn;
    public Button openBtn;

    private Interactable currentObject;

    public void Setup(Interactable obj)
    {
        currentObject = obj;

        examineBtn.gameObject.SetActive(System.Array.Exists(obj.actions, a => a == InteractableType.Examine));
        pickUpBtn.gameObject.SetActive(System.Array.Exists(obj.actions, a => a == InteractableType.PickUp));
        openBtn.gameObject.SetActive(System.Array.Exists(obj.actions, a => a == InteractableType.Open));

        examineBtn.onClick.RemoveAllListeners();
        pickUpBtn.onClick.RemoveAllListeners();
        openBtn.onClick.RemoveAllListeners();

        examineBtn.onClick.AddListener(() => obj.Interact(InteractableType.Examine));
        pickUpBtn.onClick.AddListener(() => obj.Interact(InteractableType.PickUp));
        openBtn.onClick.AddListener(() => obj.Interact(InteractableType.Open));
    }
}