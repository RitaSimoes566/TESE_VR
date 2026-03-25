using UnityEngine;

public class StarParticles : MonoBehaviour
{
    public ParticleSystem starParticles;

    public void StarsPlay()
    {
        starParticles.Play();
    }
    public void StarsStop()
    {
        starParticles.Stop();
    }
}
