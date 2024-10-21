using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject bombEffect;

    public void bomb()
    {
        StartCoroutine(bombHit());
    }

    IEnumerator bombHit()
    {
        yield return new WaitForSeconds(5f);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("Target"));

        foreach (RaycastHit enemy in rayHits)
        {
            enemy.transform.GetComponent<Target>().TakeHit();

        }
        Debug.Log("Æø¹ß");
        bombEffect.SetActive(true);
        Destroy(gameObject, 1);
    }
}
