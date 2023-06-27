using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    List<ParticleCollisionEvent> collisions = new List<ParticleCollisionEvent>();
    public GameObject Sparks;

    private void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ParticleSystem.Play();
        }
            
    }
    private void OnParticleCollision(GameObject other)
    {
        int events = ParticleSystem.GetCollisionEvents(other, collisions);
        for (int i = 0; i < events; i++)
        {
            var _spark = Instantiate(Sparks, collisions[i].intersection, Quaternion.LookRotation(collisions[i].normal));
            
        }
    }
}
