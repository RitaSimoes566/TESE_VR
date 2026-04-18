using UnityEngine;
using System.Collections;
using UnityEngine.XR.Management;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Flying : MonoBehaviour {

    public GameObject player;
    public GameObject warnBlock;

    private Animator flyAnim;
    private Animator warningAnim;

    private int direction;
    public int score = 0;

    private bool hitBlock;
    private bool isBlock;
    //private bool isScored;

    public AudioManager scoreAudio;

    void Awake()
    {
        score = 0;
        flyAnim = GetComponent<Animator>();
        warningAnim = warnBlock.GetComponent<Animator>();
        isBlock = false;
        hitBlock = false;

        StartCoroutine(FlyRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player") && isBlock)
            {
                // you have hit the block :(
                hitBlock = true;
                Debug.Log("You have hit the block :(");

            }
    }


    public IEnumerator FlyRoutine()
    {
        while (score < 5)
        {
            isBlock = false;
            hitBlock = false;

            // Stop block animation / reset state
            flyAnim.SetInteger("direction", 0);

            // Choose direction: 1 = left, 2 = right, 3 = up
            direction = Random.Range(1, 4);

            // Show warning
            warningAnim.SetInteger("direction", direction);
            warningAnim.SetBool("isWarning", true);

            yield return new WaitForSeconds(5f);

            // Hide warning
            warningAnim.SetBool("isWarning", false);
            warningAnim.SetInteger("direction", 0);

            // Start block animation
            isBlock = true;
            flyAnim.SetInteger("direction", direction);

            yield return new WaitForSeconds(5f);

            if (!hitBlock) 
            {
                score += 1;
                scoreAudio.ScoreIncrease();
            }
            
        }
    }
}
