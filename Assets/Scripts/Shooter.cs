using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform scopeTransform;
    [SerializeField] AudioSource bSound;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bEffect;

    private void Update()
    {
        if (Physics.Raycast(scopeTransform.position, -scopeTransform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(scopeTransform.position, -scopeTransform.forward * hit.distance, Color.red);
         
        }
    }

    public void Fire()
    {
        muzzleFlash.Play();
        bSound.Play();
        Debug.Log("�߻�");
        if (Physics.Raycast(scopeTransform.position, -scopeTransform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(scopeTransform.position, -scopeTransform.forward * hit.distance, Color.red);
            GameObject hitBullet = GameObject.Instantiate(bEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitBullet, 2f);
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                    target.TakeHit();
            }
        }
    }
}
