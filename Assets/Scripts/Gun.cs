using System;
using System.Collections;
using System.Data.Common;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }

    public State CurrentState {get; private set;}

    public Transform fireTransform;
    private AudioSource gunAudio;
    public ParticleSystem muzzleFlashEffect;
    private LineRenderer bulletLineRenderer;
    public GunData gunData;

    public float fireDistance = 50f;
    public float lastFireTime;

    private void Awake()
    {
        bulletLineRenderer = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }


    private void OnEnable()
    {
        CurrentState = State.Ready;
        lastFireTime = 0f;
    }

    public void Fire()
    {
        if(CurrentState == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire)
        {
            lastFireTime = Time.time;
            shoot();
        }
    }


        private void shoot()
    {
        Vector3 hitPosition;

        Ray ray = new Ray(fireTransform.position, fireTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, fireDistance, targetLayer))
        {
            hitPosition = hit.point;
            IDamageable target = hit.collider.GetComponent<IDamageable>();
            if(target != null)
            {
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
        }
        else
        {
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        }
        StartCoroutine(CoShotEffect(hitPosition));
    }

    private IEnumerator CoShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        gunAudio.PlayOneShot(gunData.shotClip);

        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);

        bulletLineRenderer.enabled = false;
        
    }

    public LayerMask targetLayer;

}
