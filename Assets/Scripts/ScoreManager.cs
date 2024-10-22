using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] List<float> score = new List<float>();
    [SerializeField] float bestScore;

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

    public void Clear(float nScore)
    {
        score.Add(nScore);
        Debug.Log($"{score[score.Count - 1]}");
        if (score[score.Count - 1] > bestScore)
        {
            bestScore = nScore;
        }
    }
}
