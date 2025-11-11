using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_prefabs; 
    [SerializeField] private int m_poolSize = 4; 

    private Queue<GameObject> _pool = new();
    public static ObjectPoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        ValidatePrefabsArray();
        InitializePool();
    }

    private void ValidatePrefabsArray()
    {
        if(m_prefabs is null || m_prefabs.Length == 0)
        {
            Debug.LogWarning("Array is empty");
        }

        for (int i = 0; i < m_prefabs.Length; i++) 
        {
            if (m_prefabs[i] is null)
            {
                Debug.LogWarning($"Array element ¹{i} is null");
            }
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < m_poolSize; i++)
        {
            CreateNewObject(); 
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if (_pool.Count == 0)
        {
            CreateNewObject();
        }

        GameObject obj = _pool.Dequeue();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }

    private void CreateNewObject()
    {
        GameObject randomPrefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
        GameObject obj = Instantiate(randomPrefab);
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}