using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    public int health;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        if (health == 0)
        {
            //player is dead = respawn
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
