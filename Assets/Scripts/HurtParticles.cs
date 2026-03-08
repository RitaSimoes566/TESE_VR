using UnityEngine;

public class HurtParticles : MonoBehaviour
{
    public ParticleSystem hurtParticles;
    public void Hurt()
    {
        hurtParticles.Play();
    }
}

   
