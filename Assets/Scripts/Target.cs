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
    }

}
