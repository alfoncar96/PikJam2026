using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectName = "Objeto";
    public InteractableType[] actions;

    public void Interact(InteractableType action)
    {
        switch (action)
        {
            case InteractableType.Examine:
                Examine();
                break;
            case InteractableType.PickUp:
                PickUp();
                break;
            case InteractableType.Open:
                Open();
                break;
        }
    }

    protected virtual void Examine()
    {
        Debug.Log("Examinando " + objectName);
        // Aquí puedes abrir un overlay con texto o detalles
        InteractionManager.Instance.ShowExamine(this);
    }

    protected virtual void PickUp()
    {
        Debug.Log("Recogiendo " + objectName);
        // Aquí se añadiría al inventario
        InteractionManager.Instance.PickUpItem(this);
        Destroy(gameObject);
    }

    protected virtual void Open()
    {
        Debug.Log("Abriendo " + objectName);
        // Puede contener objetos dentro o activar un evento
        InteractionManager.Instance.OpenContainer(this);
    }
}