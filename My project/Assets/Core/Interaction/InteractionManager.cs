using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public InteractionPopup popupPrefab;
    private InteractionPopup currentPopup;

    private Interactable currentObject;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (currentObject == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Por simplicidad abrimos primer acción
            currentObject.Interact(currentObject.actions[0]);
        }
    }

    public void ShowPopup(Interactable obj)
    {
        if (currentPopup != null) Destroy(currentPopup.gameObject);

        currentPopup = Instantiate(popupPrefab);
        currentPopup.Setup(obj);
        currentObject = obj;
    }

    public void HidePopup()
    {
        if (currentPopup != null) Destroy(currentPopup.gameObject);
        currentObject = null;
    }

    public void ShowExamine(Interactable obj)
    {
        // Aquí activas el overlay de descripción
    }

    public void PickUpItem(Interactable obj)
    {
        // Aquí añades a inventario
    }

    public void OpenContainer(Interactable obj)
    {
        // Aquí generas items o desbloqueas algo
    }
}