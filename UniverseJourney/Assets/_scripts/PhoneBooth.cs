using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneBooth : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner component not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(enemySpawner != null && enemySpawner.currentEnemy == 0)
        {
            SceneManager.LoadScene("L2");
        }
        
    }
}
