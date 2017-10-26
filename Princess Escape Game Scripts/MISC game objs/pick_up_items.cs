using UnityEngine;
using System.Collections;

public class pick_up_items : MonoBehaviour {
    //can be attached to any object that is a trigger.

    public hero_inventory.pickUpItems itemType;
    public int itemCount = 1;
    private bool isPickedUp = false;

  
    void OnTriggerEnter(Collider collider)
{
        hero_Status playerStatus;
        playerStatus = collider.GetComponent<hero_Status>();
        if (playerStatus == null) return;

        if (isPickedUp) return;

        hero_inventory heroInventory = collider.GetComponent<hero_inventory>();
        heroInventory.getItem(itemType, itemCount);
        if (itemType == hero_inventory.pickUpItems.HealthTonic)
        { heroInventory.UseItem(itemType, 1); } //use the health tonic to up health

        isPickedUp = true;

        //destroys object after we've picked it up.
        gameObject.SetActive(false); //disable this
    }
}
