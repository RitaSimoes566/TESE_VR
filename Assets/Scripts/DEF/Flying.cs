using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.XR.Management;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Flying : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject warnBlock;
    [SerializeField] private TextMeshProUGUI momText;
    private CapsuleCollider playerCol;

    private Animator flyAnim;
    private Animator warningAnim;

    private int direction;
    public int score = 0;

    private bool hitBlock;
    private bool isBlock;
    //private bool isScored;

    public List<string> momDialogue;
    public AudioManager scoreAudio;

    void Awake()
    {
        score = 0;

        playerCol = player.GetComponent<CapsuleCollider>();
        flyAnim = GetComponent<Animator>();
        warningAnim = warnBlock.GetComponent<Animator>();
        isBlock = false;
        hitBlock = false;
        momText.SetText(momDialogue[0]);

        StartCoroutine(FlyRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Triggered by: {other.name}, root: {other.transform.root.name}, tag: {other.tag}");

        if (other == playerCol && isBlock && !hitBlock)
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
            momText.SetText(momDialogue[0]);
            hitBlock = false;
            isBlock = false;

            // Stop block animation / reset state
            flyAnim.SetInteger("direction", 0);

            // Choose direction: 1 = left, 2 = right, 3 = up
            direction = Random.Range(1, 4);
            int r = Random.Range(1, 3);
            SetMotherDialogue(r, 2+ direction);

            // Show warning
            warningAnim.SetInteger("direction", direction);
            warningAnim.SetBool("isWarning", true);

            yield return new WaitForSeconds(5f);

            // Hide warning
            warningAnim.SetBool("isWarning", false);
            warningAnim.SetInteger("direction", 0);
            momText.SetText(momDialogue[0]);

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

    void SetMotherDialogue(int n, int m)
    {
        momText.SetText(momDialogue[n] + "\n" + momDialogue[m]);
    }
}

