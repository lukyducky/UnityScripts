using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACTransit.UI
{
    public class Plus1PooledObj : MonoBehaviour {
        /// <summary>
        /// basic object pooling system; is technically unlimited so use it for something that won't be endlessly called at once
        /// </summary>
        [System.NonSerialized]
        plus1pool poolInstanceForPrefab;
        

        public T GetPooledInstance<T>() where T: Plus1PooledObj {
            if (!poolInstanceForPrefab) {
                poolInstanceForPrefab = plus1pool.GetPool(this);

            }
            return (T)poolInstanceForPrefab.GetObject();
        }

        public plus1pool Pool { get; set; }

        public void ReturnToPool(){
            Debug.Log(Pool);
            if (Pool){
                { Pool.AddObject(this); }
            }
            else{
                Debug.Log("im dying");
                Destroy(gameObject);
            }
        }




    }
}