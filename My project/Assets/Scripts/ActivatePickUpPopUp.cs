using UnityEngine;

public class ActivatePickUpPopUp : MonoBehaviour
{

    public GameObject inventoryObject;

    public InventoryPoint inventoryPoint;

    public PopUpManager popUpManager;

    private GameObject collidedObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnEnable()
    {
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaa22222222222222aaaaaaaaaaaa");
    }

    // Update is called once per frame
    void Update()
    {

        collidedObject = popUpManager.collidedObject;



        inventoryPoint = collidedObject.GetComponent<InventoryPoint>();

        inventoryObject = inventoryPoint.inventoryObject;

        if (inventoryObject != null)
        {

            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKLSJLDiajsdpijnadpjasdijasdiojas");

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {

            Destroy(collidedObject);

            Debug.Log("aaaaaaaaaaaaaaa3333333333333333333333333aaaaaaaaaaaaaaaaaaa");

        }

    }
}
