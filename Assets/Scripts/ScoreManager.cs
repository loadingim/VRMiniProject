using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] List<float> arScores = new List<float>();
    [SerializeField] List<float> bombScores = new List<float>();
    [SerializeField] float arbestScore;
    [SerializeField] float bombbestScore;
    [SerializeField] TextMeshProUGUI arScore;
    [SerializeField] TextMeshProUGUI bombScore;

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
        if (TargetSpawner.Instance.gameObject.tag == "AR")
        {
            arScores.Add(nScore);
            if (arbestScore == 0)
            {
                arbestScore = nScore;
                arScore.text = $"AR BEST SCORE :{arbestScore}";
            }
            else if (arScores[arScores.Count - 1] < arbestScore)
            {
                arbestScore = nScore;
                arScore.text = $"AR BEST SCORE :{arbestScore}";
            }
        }


        if (TargetSpawner.Instance.gameObject.tag == "BOMB")
        {
            bombScores.Add(nScore);
            if (arbestScore == 0)
            {
                bombbestScore = nScore;
                bombScore.text = $"BOMB BEST SCORE :{bombbestScore}";
            }
            
            else if (bombScores[bombScores.Count - 1] < bombbestScore)
            {
                bombbestScore = nScore;
                bombScore.text = $"BOMB BEST SCORE :{bombbestScore}";
            }            
        }
    }
}
