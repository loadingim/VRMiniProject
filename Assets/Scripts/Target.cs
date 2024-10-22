using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void TakeHit()
    {
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
            TargetSpawner.Instance.targetCount--;

        if(TargetSpawner.Instance.targetCount <= 0)
        {
            TargetSpawner.Instance.scoreTime = false;
            ScoreManager.Instance.Clear(TargetSpawner.Instance.score);
        }
    }

}
