using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    private List<Enemy> enemies;
    public TextMeshProUGUI zombiesText;
    public int currentEnemy;

    [Range(0, 100)]
    public int numberOfEnemies = 25;
    private float range = 70.0f;

    void Start()
    {
        enemies = new List<Enemy>(); // init as type
        for (int index = 0; index < numberOfEnemies; index++)
        {
            Enemy spawned = Instantiate(enemy, RandomNavmeshLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
        }

        currentEnemy = numberOfEnemies;
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
     void Update()
    {
        zombiesText.text = "Enemy Counter: " + currentEnemy.ToString();
    }
}