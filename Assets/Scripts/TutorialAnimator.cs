using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{

    [SerializeField] Animator tutAnim;
    private bool isT;

    private void Awake()
    {
        isT = true;
        EnterTutorial();
    }
    public void EnterTutorial()
    {
        tutAnim.SetBool("isTutorial", true);
    }

    public void LeaveTutorial()
    {
        tutAnim.SetBool("isTutorial", false);
    }

    public void ChangeButton()
    {
        isT = !isT;
        if (isT)
        {
            EnterTutorial();
        } else
        {
            LeaveTutorial();
        }
    
    }
}
