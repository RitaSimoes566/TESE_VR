using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class SceneChanger : MonoBehaviour
{
    public GameObject player;

    public void GoToBranch()
    {
        SceneManager.LoadScene("ATTACK_BRANCH");
        player.transform.position = new Vector3(-2, 0, 2.8f);
    }

    public void GoToBasket()
    {
        SceneManager.LoadScene("ATTACK_BASKET");
        player.transform.position = new Vector3(-2, 0, 2.6f);
    }

    public void GoToDefense()
    {
        SceneManager.LoadScene("Defense");
        //player.transform.position = new Vector3(-3.7f, 2, 4f);
    }
}
