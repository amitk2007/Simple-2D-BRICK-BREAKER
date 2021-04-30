using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int points;
    public static int life;
    public static int totalBricks;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;

    public GameObject endScreen;
    public TextMeshProUGUI endScreenText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        life = 5;
        totalBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    public void AddPoints(int pointsToAdd)
    {
        points = points + pointsToAdd;
        pointsText.text = points.ToString();

        if (totalBricks - points == 0)
        {
            endScreen.SetActive(true);
            endScreenText.text = "You Won!";
            Time.timeScale = 0;
        }
    }

    public void RemoveLife(int lifeToRemove)
    {
        life = life - lifeToRemove;
        if (life > 0)
        {
            lifeText.text = life.ToString();
        }
        else
        {
            endScreen.SetActive(true);
            endScreenText.text = "You Lost";
            Time.timeScale = 0;
        }

    }



}
