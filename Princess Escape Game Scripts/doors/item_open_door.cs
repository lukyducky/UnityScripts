using UnityEngine;
using System.Collections;

public class item_open_door : MonoBehaviour {
    hero_inventory inventory;
    public hero_inventory.pickUpItems item;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        inventory = other.GetComponent<hero_inventory>();
        if (inventory.hasItem(item))
        {
            inventory.UseItem(item, 1); //use the item
            gameObject.SetActive(false); //disable this
        }
    }



}
