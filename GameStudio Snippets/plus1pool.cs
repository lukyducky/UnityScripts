using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACTransit.UI
{
    public class plus1pool : MonoBehaviour
    {
        Plus1PooledObj prefab;

        List<Plus1PooledObj> availableObjects = new List<Plus1PooledObj>();

        public Plus1PooledObj GetObject(){
            Plus1PooledObj obj;
            int lastAvailIndex = availableObjects.Count - 1;
            if(lastAvailIndex > 0) {
                //get the object
                obj = availableObjects[lastAvailIndex];
                availableObjects.RemoveAt(lastAvailIndex);
                obj.gameObject.SetActive(true);
            }
            else{
                //make an object
                obj = Instantiate<Plus1PooledObj>(prefab);
                obj.transform.SetParent(transform, false);
                obj.Pool = this;
            }        
            return obj;
        }

        public void AddObject(Plus1PooledObj o){
                o.gameObject.SetActive(false);
                availableObjects.Add(o);

        }

        public static plus1pool GetPool(Plus1PooledObj prefab) {
            GameObject obj;
            plus1pool pool;
            if (Application.isEditor){
                obj = GameObject.Find(prefab.name + " Pool");
                if (obj){
                    pool = obj.GetComponent<plus1pool>();
                    if (pool) {
                        return pool;  
                    }

                }
            }
            obj = new GameObject(prefab.name + " Pool");
            pool = obj.AddComponent<plus1pool>();
            pool.prefab = prefab;
            return pool;

        }

    }
}