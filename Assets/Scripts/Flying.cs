using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour
{
    private Animator flyAnim;
    private int direction;

    void Awake()
    {
        flyAnim = GetComponent<Animator>();
        StartCoroutine(FlyRoutine());
    }

    private IEnumerator FlyRoutine()
    {
        while (true)
        {
            direction = 0;
            flyAnim.SetInteger("direction", direction);
            yield return new WaitForSeconds(3f);

            direction = Random.Range(1, 4);
            flyAnim.SetInteger("direction", direction);
            yield return new WaitForSeconds(3f);
        }
    }
}
