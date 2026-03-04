using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ball;
    public TextMeshProUGUI text;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText("Pontuação: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 startPos = new Vector3(-1, 1, 3);

        if (other.gameObject == enemy)
        {
            Debug.Log("hi");
            ball.transform.position = startPos;
            score += 1;
            text.SetText("Pontuação: " + score);
        }
    }
}
