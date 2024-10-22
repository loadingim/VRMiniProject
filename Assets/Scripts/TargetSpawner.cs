using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance { get; private set; }
    private Coroutine targetSpawn;
    public float targetCount;
    [SerializeField] float level;
    [SerializeField] GameObject targetPrefab;
    public float targets, score;
    [SerializeField] bool canSpawn;
    [SerializeField] GameObject gunPrefabs, gunSpawn, gun;
    [SerializeField] GameObject bombPrefabs, bombSpawn, bomb;
    public bool scoreTime;
    [SerializeField] Transform bombSpawner, sniperSpawner, arSpawner;
    [SerializeField] Target[] trashTarget;
    //[SerializeField] GameObject sniperPrefabs, sniperSpawn, sniper;

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

        if (scoreTime == true)
        {
            score += Time.deltaTime;
        }
    }

    public void ResetButton()
    {
        StopCoroutine(targetSpawn);
        trashTarget = FindObjectsOfType<Target>();

        foreach (Target tTarget in trashTarget)
        {
            Destroy(tTarget.gameObject);
        }
        Destroy(gun);
        Destroy(bomb);
        
        targetCount = 20;
        canSpawn = true;
        level = 1;
    }

    public void GunSpawn()
    {
        Vector3 spawn = gunSpawn.transform.position;
        if (gun == null)
        {
            gun = Instantiate(gunPrefabs, spawn, transform.rotation);
        }
        else
        {
            Destroy(gun);
            gun = Instantiate(gunPrefabs, spawn, transform.rotation);
        }
    }

    public void BombSpawn()
    {
        Vector3 spawn = bombSpawn.transform.position;
        if (bomb == null)
        {
            bomb = Instantiate(bombPrefabs, spawn, transform.rotation);
        }
        else
        {
            Destroy(bomb);
            bomb = Instantiate(bombPrefabs, spawn, transform.rotation);
        }
    }

 /*   public void SniperSpawn()
    {
        Vector3 spawn = sniperSpawn.transform.position;
        if (sniper == null)
        {
            sniper = Instantiate(sniperPrefabs, spawn, transform.rotation);
        }
        else
        {
            Destroy(sniper);
            sniper = Instantiate(sniperPrefabs, spawn, transform.rotation);
        }
    }*/

    #region 레벨
    public void Level1()
    {
        if (gameObject.tag == "AR")
        {
            targetCount = 30;
        }

        if (gameObject.tag == "BOMB")
        {
            targetCount = 5;
        }
    }
    public void Level2()
    {
        if (gameObject.tag == "AR")
        {
            targetCount = 40;
        }

        if (gameObject.tag == "BOMB")
        {
            targetCount = 7;
        }
    }
    public void Level3()
    {
        if (gameObject.tag == "AR")
        {
            targetCount = 50;
        }

        if (gameObject.tag == "BOMB")
        {
            targetCount = 9;
        }
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
        if (gameObject.tag == "AR")
        {
            targets = targetCount;
            gameObject.transform.position = arSpawner.position;
            yield return new WaitForSeconds(5f);
            canSpawn = false;
            score = 0;
            scoreTime = true;
            for (int i = 0; i < targets; i++)
            {
                Vector3 spawn = new Vector3(Random.Range(-9, 9f), Random.Range(2f, 5f), Random.Range(15f, 42f));

                Instantiate(targetPrefab, spawn, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0f, 2f));
            }
        }

        if (gameObject.tag == "BOMB")
        {
            targets = targetCount;
            yield return new WaitForSeconds(5f);
            canSpawn = false;
            score = 0;
            scoreTime = true;
            for (int i = 0; i < targets; i++)
            {
                Vector3 spawn = new Vector3(Random.Range(10.5f, 19.5f), 1, Random.Range(15f, 42f));

                Instantiate(targetPrefab, spawn, transform.rotation);
            }
        }
        yield break;
    }
    #endregion

    public void ArTag()
    {
        gameObject.tag = "AR";
    }

    public void BombTag()
    {
        gameObject.tag = "BOMB";
    }

/*    public void SniperTag()
    {
        gameObject.tag = "SNIPER";
    }*/
}
