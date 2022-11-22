using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public List<GameObject> pooledObjectsEnemy;
    public GameObject objectToPool;
    public GameObject objectToPoolEnemy;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        pooledObjectsEnemy = new List<GameObject>();
        for (int i = 0; i < amountToPool*3; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolEnemy);
            obj.SetActive(false);
            pooledObjectsEnemy.Add(obj);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
       // while (pooledObjects.Count < 1)
        //{
         //   GetCreateBullet();
         //   GetPooledObject();
       // }
        //3   
        return null;
    }
    public GameObject GetPooledObjectEnemy()
    {
        //1
        for (int i = 0; i < pooledObjectsEnemy.Count; i++)
        {
            //2
            if (!pooledObjectsEnemy[i].activeInHierarchy)
            {
                pooledObjectsEnemy[i].SetActive(true);
                return pooledObjectsEnemy[i];
            }
        }
        //while (pooledObjectsEnemy.Count<1)
       // {
         //   GetCreateEnemyBullet();
       // }
        //3   
        return null;
    }
    public GameObject GetCreateEnemyBullet()
    {
        pooledObjectsEnemy = new List<GameObject>();
        for (int i = 0; i < amountToPool * 3; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolEnemy);
            obj.SetActive(false);
            pooledObjectsEnemy.Add(obj);
        }
        return null;
    }
    public GameObject GetCreateBullet()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool * 3; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        return null;
    }
}
