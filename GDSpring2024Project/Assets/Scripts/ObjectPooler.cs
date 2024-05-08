using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    private Dictionary<string, List<GameObject>> pooledObjects = new Dictionary<string, List<GameObject>>();

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void CreateObjectPool(GameObject prefab, int initialPoolSize){
        string key = prefab.name;

        if(!pooledObjects.ContainsKey(key)){
            pooledObjects.Add(key, new List<GameObject>());

            for(int i = 0; i < initialPoolSize; i++){
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                pooledObjects[key].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(GameObject prefab){
        string key = prefab.name;

        if(pooledObjects.ContainsKey(key)){
            for(int i = 0; i < pooledObjects[key].Count; i++){
                if(!pooledObjects[key][i].activeInHierarchy){
                    return pooledObjects[key][i];
                }
            }
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects[key].Add(obj);
            return obj;
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
