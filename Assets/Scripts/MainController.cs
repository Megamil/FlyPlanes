using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    bool isEndGame;
    [SerializeField] GameObject painelUI;
    [SerializeField] GameObject imageGameOver;
    [SerializeField] GameObject pause;
    [SerializeField] int life;
    [SerializeField] int score;
    [SerializeField] Text txtLife;
    [SerializeField] Text txtScore;

    SpriteRenderer sprite;
    bool imortal;


    private void Awake()
    {
        Time.timeScale = 1;
        this.isEndGame = false;
        this.imortal = false;
        this.life = 3;
        this.score = 0;
        this.txtLife.text = "Lifes: "+ life;
        this.txtScore.text = "" + score;
    }

    public void pauseGame()
    {
        if(isEndGame) {return;}

        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            pause.SetActive(false);
        } else {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void gameOver()
    {
        this.isEndGame = true;
        this.painelUI.SetActive(true);
        this.imageGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void onTryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void hit(PlaneController plane)
    {
        if (imortal) { return; }
        imortal = true;
        sprite = plane.GetComponent<SpriteRenderer>();

        this.life -= 1;
        this.txtLife.text = "Lifes: "+life;
        if(this.life == 0)
        {
            this.gameOver();
        } else
        {
            StartCoroutine(DamageEffect());
        }
    }

    public IEnumerator DamageEffect()
    {
        sprite.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 1f, 1f, 1f);

        for (int i = 0; i < 7; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }

        imortal = false;

    }

    public void toScore()
    {
        this.score += 1;
        this.txtScore.text = ""+ this.score;
    }

}