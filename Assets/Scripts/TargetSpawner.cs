using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private Coroutine targetSpawn;
    [SerializeField] float targetCount;
    [SerializeField] float level;
    [SerializeField] GameObject targetPrefab;
    public float targets;
    [SerializeField] bool canSpawn;

    private void Start()
    {
        targetCount = 20;
        canSpawn = true;
        level = 1;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("½ÇÇà");
            canSpawn = true;
            level++;

            switch (level)
            {
                case 1:
                    targetCount = 20;
                    break;
                case 2:
                    targetCount = 30;
                    break;
                case 3:
                    targetCount = 40;
                    break;
                case 4:
                    targetCount = 50;
                    break;
                default:
                    break;
            }

            Spawn();
        }
    }

    public void Spawn()
    {
        if (canSpawn == true)
            targetSpawn = StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster()
    {
        canSpawn = false;
        targets = targetCount;

        for (int i = 0; i < targetCount; i++)
        {
            Vector3 spawn = new Vector3(Random.Range(-9, 9f), Random.Range(2f, 5f), Random.Range(15f, 42f));

            Instantiate(targetPrefab, spawn, transform.rotation);
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }

        yield break;
    }
}
