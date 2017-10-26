using UnityEngine;
using System.Collections;

public class hero_inventory : MonoBehaviour
{

    //defines datastructure to hold pickup items; should be attached to hero chara gameObject


    public enum pickUpItems { Debug_Item, HealthTonic, Weapon, Clothes, Torch, Explosives, Key, Count}


    int[] heroInventory;

    hero_Status playerStatus;

    void Start()
    {
        playerStatus = GetComponent<hero_Status>();
        heroInventory = new int[(int)pickUpItems.Count];
        foreach (pickUpItems item in heroInventory)
        {
            heroInventory[(int)item] = 0;
        }
        heroInventory[(int)pickUpItems.HealthTonic] = 1;
    }

    private float HealthTonicCount = 0;
    
    public void getItem(pickUpItems item, int amount)
    {
        heroInventory[(int)item] += amount;
    }

    public void UseItem(pickUpItems item, int amount)
    {
        if(heroInventory[(int)item] <= 0) { return; }
        heroInventory[(int)item] -= amount; //item has been used so reduce stock

        switch (item)
        {
            case pickUpItems.HealthTonic:
                playerStatus.addHealth(5f);
                break;
            case pickUpItems.Explosives:
                //exposive thing here
                break;
            default:
                break;
        }
    }

    //checks if item has more than given number n
    bool compareItemCount(pickUpItems compItem, int n)
    {
        return heroInventory[(int)compItem] >= n;
    }

    //returns val of inventory item
    public int getItemCount(pickUpItems inItem) { return heroInventory[(int)inItem]; }

    public bool hasItem(pickUpItems inItem)
    {
        if (heroInventory[(int)inItem] != 0) { return true; }
        else { return false; }
    }

    void OnGUI() { GUI.Label(new Rect(30, 30, 150, 30), "Health Tonic Count" + getItemCount(pickUpItems.HealthTonic)); }
    
}
