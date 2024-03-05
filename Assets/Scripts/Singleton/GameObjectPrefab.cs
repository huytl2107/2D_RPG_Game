using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPrefab : Singleton<GameObjectPrefab>
{
    [SerializeField] private GameObject plantingAreaPrefab;

    public override void Awake()
    {
        base.Awake(); // Gọi hàm Awake() của lớp cha Singleton
        DontDestroyOnLoad(gameObject);
    }

    public GameObject GetPlantingArea(Vector3 position)
    {
        // Làm tròn vị trí của player về .5 cho x và y
        float roundedX = Mathf.Round(position.x) + .5f;
        float roundedY = Mathf.Round(position.y) + .5f;
        Vector3 roundedPosition = new Vector3(roundedX, roundedY, position.z);

        // Tạo một instance mới của PlantingArea tại vị trí đã được làm tròn
        GameObject newPlantingArea = Instantiate(plantingAreaPrefab, roundedPosition, Quaternion.identity);
        
        return newPlantingArea;
    }
}
