using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSimulation : MonoBehaviour
{
    float spinTime;
    float eulerZ;
    float decreaseTime;

    SpriteRenderer SpRenderer;
    Color fade;

    Vector3 movePos;
    ParticleType PT;
    void Start()
    {
        SpRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (StaticVals.isStopped == true)
            return;

        if (PT == ParticleType.Shell)
        {
            float moveSpeed = 6f;
            Vector2 movePos2D = new Vector2(movePos.x, movePos.y);
            transform.position = Vector2.MoveTowards(transform.position, movePos2D, moveSpeed * Time.deltaTime);
        }

        if(spinTime < 1 && PT != ParticleType.Trail)
        {
            float random = Random.Range(1f, 4f);
            float eulerSpeed = 360f * random;
            eulerZ += eulerSpeed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0f, 0f, eulerZ);
            spinTime += Time.deltaTime;
        }

        fade.a -= Time.deltaTime;

        if (PT == ParticleType.Trail)
        {
            SpRenderer.color = fade;
            Destroy(gameObject, 2f);
        }

    }

    public static void CreateAmmoShell(Transform shell, Vector3 spawnPos, Vector3 move, Transform rot)
    {
        Transform shellTransform = Instantiate(shell, spawnPos, rot.rotation);
        ParticleSimulation Ps = shellTransform.gameObject.AddComponent<ParticleSimulation>();
        Ps.Setup(move);
    }

    void Setup(Vector3 move)
    {
        this.PT = ParticleType.Shell;
        this.movePos = move;
        transform.localScale = Vector3.one;
        eulerZ = 0f;
    }

    public static void CreateBloodEffect(Transform blood, Vector3 spawnPos, Transform rot)
    {
            Transform bloodTransform = Instantiate(blood, spawnPos, rot.rotation);
            ParticleSimulation Ps = bloodTransform.gameObject.AddComponent<ParticleSimulation>();
            Ps.SetUpBloodParticle();
    }

    void SetUpBloodParticle()
    {
        this.PT = ParticleType.Blood; 
        eulerZ = 0f;
    }

    public static void CreateSingleParticle(Transform particle, Vector3 spawnPos)
    {
        Transform particleTransform = Instantiate(particle, spawnPos, Quaternion.identity);
        ParticleSimulation Ps = particle.gameObject.AddComponent<ParticleSimulation>();
        Ps.SetupNormalParticle();
    }

    void SetupNormalParticle()
    {
        this.PT = ParticleType.Normal;
        eulerZ = -1f;
    }


    public static void CreateTrailParticle(Transform particle,Vector3 spawnPos)
    {
        Transform particleTransform = Instantiate(particle, spawnPos, Quaternion.identity);
        ParticleSimulation Ps = particleTransform.gameObject.AddComponent<ParticleSimulation>();
        Ps.SetupTrailEffect();
    }

    void SetupTrailEffect()
    {
        this.PT = ParticleType.Trail;
        fade = Color.white;
        decreaseTime = 0f;
        eulerZ = 2f;
    }

}
public enum ParticleType
{
    Shell,
    Blood,
    Normal,
    Trail
}