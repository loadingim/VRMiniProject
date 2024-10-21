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
    [SerializeField] float bombTime;
    [SerializeField] bool buttonClick;
    private Vector3 muzzlePoint;
    [SerializeField] GameObject ballPrefab;

    public void PointerDown()
    {
        buttonClick = true;
    }

    private void Update()
    {
        if (buttonClick)
        {
            bombTime += 10f * Time.deltaTime;
        }
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
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                    target.TakeHit();
            }
        }
    }

    public void Shoot()
    {
        muzzlePoint = Camera.main.transform.position;
        Debug.Log("Ŭ���Ϸ�");
        GameObject ball = Instantiate(ballPrefab, muzzlePoint, Camera.main.transform.rotation);
        Rigidbody rigid = ball.GetComponent<Rigidbody>();
        rigid.velocity = bombTime * Camera.main.transform.forward;

        buttonClick = false;
        bombTime = 0;
    }
}
