using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public GameObject[] slots;

    Text text;

    private int numSlotsMax = 7;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        slots = new GameObject[numSlotsMax];

    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public GameObject[] getSlots()
    {





        return this.slots;

    }


    public void setSlot()
    {

        Component[] inventario = GameObject.FindGameObjectWithTag("Inventary").GetComponentsInChildren<Transform>();

        bool slotUsed = false;

        if (removeItems(inventario))
        {

            for (int i = 0; i < slots.Length; i++)
            {

                if (slots[i] != null)
                {

                    slotUsed = false;

                    for (int e = 0;  e < inventario.Length; e++)
                    {


                        GameObject child = inventario[e].gameObject;

                        if (child.tag == "slot" && child.transform.childCount <= 1 && !slotUsed)
                        {

                            GameObject item = Instantiate(slots[i], child.transform.position, Quaternion.identity);
                            item.transform.SetParent(child.transform, false);
                            item.transform.localPosition = new Vector3(0, 0, 0);
                            item.name = item.name.Replace("Clone", "");

                        }


                    }



                }




            }


        }



    }

    public bool removeItems()
    {

        return true;

    }

}
