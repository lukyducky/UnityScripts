using UnityEngine;
using System.Collections;

public class destructible : MonoBehaviour {

    public int hp = 2;
	
    //called when object is attacked;s
    public void damageThis(int loss)
    {
        hp -= loss;
        if (hp <= 0)
        {
            gameObject.SetActive(false); //disable this
        }
    }
}
