using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance { get; private set; }
    private List<GameObject> _pooledObjects;
    [SerializeField] private GameObject objectToPool = default;
    [SerializeField] private int amountToPool = default;

    private void Awake()
    {
        if (SharedInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        SharedInstance = this;
    }

    private void Start()
    {
        CreateObjects();
    }

    private void CreateObjects()
    {
        _pooledObjects = new List<GameObject>();
        for (var i = 0; i < amountToPool; i++)
        {
            var pooledObject = Instantiate(objectToPool, transform, false);
            pooledObject.SetActive(false);
            _pooledObjects.Add(pooledObject);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var pooledObject in _pooledObjects)
        {
            if (!pooledObject.activeInHierarchy)
            {
                return pooledObject;
            }
        }

        return null;
    }
}