using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    List<T> _pool;


    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        container = null;

        CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab=prefab;
        this.container = container;

        CreatePool(count);
    }
    
    void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObjects();
        }
    }

    private T CreateObjects(bool IsActiveByDefaults = false)
    {
        var createdObjects = UnityEngine.Object.Instantiate(prefab,container);
        createdObjects.gameObject.SetActive(IsActiveByDefaults);
        _pool.Add(createdObjects);
        return createdObjects;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
            return element;
        if (autoExpand)
            return CreateObjects(true);

        throw new Exception($"There is no free elements in pool of type {typeof(T)}");
    }
}
