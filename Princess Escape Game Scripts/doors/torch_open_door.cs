using UnityEngine;
using System.Collections;

public class torch_open_door : MonoBehaviour {

    hero_inventory inventory;
    public hero_inventory.pickUpItems item;

    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        inventory = other.GetComponent<hero_inventory>();
        if (inventory.hasItem(item))
        {
            gameObject.SetActive(false); //disable this
            other.GetComponent<torch_open_door>().enabled = false;
        }
    }

}
