using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance { get; private set; }
    private Coroutine targetSpawn;
    public float targetCount;
    [SerializeField] float level;
    [SerializeField] GameObject targetPrefab;
    public float targets;
    [SerializeField] bool canSpawn;
    [SerializeField] GameObject gun, gunSpawn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        targetCount = 20;
        canSpawn = true;
        level = 1;

    }

    private void Update()
    {
        if (targetCount <= 0)
        {
            canSpawn = true;
        }
    }

    public void GunSpawn()
    {

    }

    #region 레벨
    public void Level1()
    {
        targetCount = 20;
    }
    public void Level2()
    {
        targetCount = 30;
    }
    public void Level3()
    {
        targetCount = 40;
    }
    public void Level4()
    {
        targetCount = 50;
    }
    public void Level5()
    {
        targetCount = 60;
    }
    #endregion

    #region 스폰
    public void Spawn()
    {
        if (canSpawn == true)
            targetSpawn = StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(5f);
        canSpawn = false;

        for (int i = 0; i < targetCount; i++)
        {
            Vector3 spawn = new Vector3(Random.Range(-9, 9f), Random.Range(2f, 5f), Random.Range(15f, 42f));

            Instantiate(targetPrefab, spawn, transform.rotation);
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }

        yield break;
    }
    #endregion
}
