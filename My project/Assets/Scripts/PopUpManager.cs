using UnityEngine;

public class PopUpManager : MonoBehaviour
{

    public GameObject openPopUp;

    public GameObject examinePopUp;

    public GameObject pickUpPopUp;

    public GameObject collidedObject;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        collidedObject = other.gameObject;

        if (other.CompareTag("OpenInteracteable"))
        {
            openPopUp.SetActive(true);

           

        }

        if (other.CompareTag("ExamineInteracteable"))
        {
            

            examinePopUp.SetActive(true);

            

        }

        if (other.CompareTag("PickUpInteracteable"))
        {

            

            pickUpPopUp.SetActive(true);

            

            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        
        
        if (other.CompareTag("OpenInteracteable"))
        {

            openPopUp.SetActive(false);

        }

        if (other.CompareTag("ExamineInteracteable"))
        {

            examinePopUp.SetActive(false);

        }

        if (other.CompareTag("PickUpInteracteable"))
        {

            pickUpPopUp.SetActive(false);

        }


    }

}
