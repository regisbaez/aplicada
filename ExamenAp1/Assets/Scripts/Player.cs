using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject GameOverText;
    float _speedX = 10f;
    Vector3 deltaPos;
    float MINI= -11.79f;
    float MAXI= 11.79f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal"), 0) * _speedX * Time.deltaTime;
        gameObject.transform.Translate(deltaPos);

        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, MINI, MAXI),
            gameObject.transform.position.y,
            gameObject.transform.position.z);
    }



    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bad":
                gameManager.DecrementLife();
                break;

            case "Good":
                gameManager.IncrementLife();
                break;
            case "VeryBad":
                gameManager.DecrementLife2();
                break;
        }

        Destroy(other.gameObject);
    }

}
