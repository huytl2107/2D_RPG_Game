using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPrefab : Singleton<GameObjectPrefab>
{
    [System.Serializable]
    public class Pool 
    {
        public GameEnum.EObjectPrefab tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public override void Awake()
    {
        base.Awake(); // Gọi hàm Awake() của lớp cha Singleton
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools) 
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for(int i=0 ; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }    
            poolDictionary.Add(pool.tag.ToString(), objectsPool);
        }
    }

    public GameObject GetPoolObject(GameEnum.EObjectPrefab eTag, Vector3 position)
    {
        string tag = eTag.ToString();
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        // Làm tròn vị trí của player về .5 cho x và y
        float roundedX = Mathf.Floor(position.x) + .5f;

        //Cần set pivot của toàn bộ object về bottom center hết để sử dụng
        float roundedY = Mathf.Floor(position.y);
        Vector3 roundedPosition = new Vector3(roundedX, roundedY, position.z);

        // Tạo một instance mới của PlantingArea tại vị trí đã được làm tròn
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.transform.position = roundedPosition;
        objToSpawn.SetActive(true);
        
        return objToSpawn;
    }
}
