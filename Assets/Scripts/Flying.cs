using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour
{
    public GameObject warnBlock;
    private Animator flyAnim;
    private Animator warningAnim;

    private bool isWarning;
    private bool isBlock;
    private int direction;
    public int score;

    void Awake()
    {
        flyAnim = GetComponent<Animator>();

        warningAnim = warnBlock.GetComponent<Animator>();
        StartCoroutine(FlyRoutine());
        isWarning = true;
    }

    private void Update()
    {
        Debug.Log(direction);
        Debug.Log(warningAnim.GetBool("isWarning"));
    }

    private IEnumerator FlyRoutine()
    {
        while (true)
        {
            
            //block wait = 0
            direction = 0;
            flyAnim.SetInteger("direction", direction);

            // decide up,left or right
            // 1 =left ; 2 = right ; 3 = up
            direction = Random.Range(1, 4);

            //warning anim
            warningAnim.SetBool("isWarning", true);
            warningAnim.SetInteger("direction", direction);

            yield return new WaitForSeconds(3f);
            warningAnim.SetBool("isWarning", false);

            // block anim
            flyAnim.SetInteger("direction", direction);
            yield return new WaitForSeconds(3f);
            warningAnim.SetBool("isWarning", true);

            // set score
        }
    }
}
