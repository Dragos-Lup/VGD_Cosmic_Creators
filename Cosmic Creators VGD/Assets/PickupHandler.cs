using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupHandler : MonoBehaviour
{
    private int count = 0;
    private bool holding = false;
    public GameObject backpack;
    public TextMeshProUGUI countText;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            if (!holding){
                holding = true;
                backpack.SetActive(true);
            }

            

        } else if (other.gameObject.CompareTag("Dropoff")) {
            if (holding){
                holding = false;
                count++;
                SetCountText();
                backpack.SetActive(false);
            }
            
        }
    }

    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
    }
}
