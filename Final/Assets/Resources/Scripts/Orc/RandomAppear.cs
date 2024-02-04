using UnityEngine;

public class RandomAppear : MonoBehaviour
{
    public GameObject enemyPrefab; // 存放敌人预制体的变量
    public int maxEnemies = 5; // 最大敌人数量
    
    void Start()
    {
        SpawnEnemies(); // 调用函数开始生成敌人
    }
    
    void SpawnEnemies()
    {
        int numOfEnemies = Random.Range(1, 6); // 设置要生成的敌人数量为3到6之间的随机值
        numOfEnemies = Mathf.Min(numOfEnemies, maxEnemies); // 限制生成的敌人数量不超过最大值
        
        for (int i = 0; i < numOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 10f), 0f, Random.Range(-5f, 10f)); // 设置敌人生成位置的随机X、Z坐标
            
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // 根据指定的位置和旋转信息生成敌人预制体
        }
    }
}
