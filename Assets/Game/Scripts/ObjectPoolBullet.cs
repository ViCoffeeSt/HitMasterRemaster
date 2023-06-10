using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolBullet : MonoBehaviour
{
    public static ObjectPoolBullet Instance;

    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 3;

    private List<GameObject> _pooledObjects;

    private int lastActiveIndex = -1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        lastActiveIndex++;
        if (lastActiveIndex >= _pooledObjects.Count)
        {
            lastActiveIndex = 0;
        }

        GameObject obj = _pooledObjects[lastActiveIndex];
        obj.SetActive(false);
        return obj;
    }
}

