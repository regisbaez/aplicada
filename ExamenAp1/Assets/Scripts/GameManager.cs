using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour


{
   
    public Player player;
    public DeadZone deadZone;
    public int CurrentScore;
    public TextMesh CurrentLivesText;
    public Left left;
    public Right right;
    public TextMesh ScoreText;
    public GameObject GameOverText;
    const float MINX = 11.79f;
    const float MAXX = -11.79f;
    public int CurrentLives;
    public GameObject Bad,Good,Trap;


    // Start is called before the first frame update
    void Start()
    {
        CurrentLives = 5;

        Instantiate(player);
        Instantiate(deadZone);


        

        InvokeRepeating("InstanciateBad", 0, 2f);
        InvokeRepeating("InstanciateGood", 10, 10f);
        InvokeRepeating("InstanciateTrap", 15, 7f);
        InvokeRepeating("InstanciateBad", 15, 2f);
        InvokeRepeating("InstanciateTrap", 30, 10f);
        InvokeRepeating("InstanciateGood", 25, 10f);
        InvokeRepeating("InstanciateBad", 35, 2f);
        InvokeRepeating("InstanciateTrap", 40, 10f);
        InvokeRepeating("InstanciateBad", 45, 2f);
        InvokeRepeating("InstanciateTrap", 50, 10f);





    }

    public int DecrementLife()
    {

        CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
        CurrentLivesText.text = CurrentLives.ToString();
        return CurrentLives;
    }
    public int DecrementLife2()
    {
        CurrentLives = CurrentLives > 0 ? CurrentLives - 2 : 0;
        CurrentLivesText.text = CurrentLives.ToString();
        return CurrentLives;
    }

    void InstanciateBad()
    {
        if (CurrentLives > 0)
        {
            Instantiate(Bad, new Vector3(Random.Range(MINX, MAXX), 6.6f, 0f), Quaternion.identity);
        }
        else
        {
            Instantiate(GameOverText);
        }
    }
    void InstanciateGood()
    {
        if (CurrentLives > 0)
        {
            Instantiate(Good, new Vector3(Random.Range(MINX, MAXX), 6.6f, 0f), Quaternion.identity);
        }
    }
    void InstanciateTrap()
    {
        if (CurrentLives > 0) 
        { 
            Instantiate(Trap, new Vector3(Random.Range(MINX, MAXX), 6.6f, 0f), Quaternion.identity);
        }

        
    }

    public int IncrementLife()
    {
        CurrentLives = CurrentLives + 1;
        CurrentLivesText.text = CurrentLives.ToString();
        return CurrentLives;
    }

    public int IncrementScore()
    {
        CurrentScore++;
        ScoreText.text = CurrentScore.ToString();
        return CurrentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
