using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCloneDeath : MonoBehaviour
{
    Rigidbody rb;
    public float killTime;
    public ParticleSystem pfx;
    private CameraShake cameraShake;
    JaeGameManager gm;

    // Use this for initialization
    void Awake()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(10, 5, 0), ForceMode.Impulse);
        //rb.AddExplosionForce(100, transform.position += new Vector3(-10, -3, 0), 20);
        StartCoroutine("BossDie", killTime);
        gm = FindObjectOfType<JaeGameManager>();
    }

    public IEnumerator BossDie(float killTime)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < killTime)
        {
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= killTime)
        {
            ParticleSystem pfxClone;
            pfxClone = Instantiate(pfx, null);
            pfxClone.transform.position = transform.position;
            pfxClone.Play();
            StartCoroutine(cameraShake.Shake(.3f, .4f));
            FindObjectOfType<AudioPlayer>().Play("Explosion");
            yield return new WaitForSeconds(0.3f);
            gm.BossIsNowDead();
            Destroy(gameObject);
            yield return null;
        }
    }
}
