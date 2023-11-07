using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public bool playEnd;
    public float limitTime;
    public int enemyCount;

    public Text timeLabel;
    public Text enemyLabel;
    public GameObject finalGUI;
    public Text finalMessage;
    public Text finalScoreLabel;

    private void Start()
    {
        enemyLabel.text = string.Format("Enemy : {0}", enemyCount);
        timeLabel.text = string.Format("Time : {0}", limitTime);
    }

    private void Update()
    {
        if (!playEnd)
        {
            if (limitTime > 0)
            {

                limitTime -= Time.deltaTime;
                timeLabel.text = string.Format("Time : {0:N2}", limitTime);
            }
            else
            {
                GameOver();
            }
        }
    }

    public void EnemyDie()
    {
        enemyCount--;
        enemyLabel.text = string.Format("Enemy : {0}", enemyCount);

        if (enemyCount <= 0)
            Clear();
    }

    public void Clear()
    {
        if (!playEnd)
        { 
            Time.timeScale = 0;
            playEnd = true;
            finalMessage.text = "Clear!!";

            PlayerController pc = 
                GameObject.Find("Player").GetComponent<PlayerController>();
            float score = 12345f + limitTime * 123f + pc.hp * 123f;
            finalScoreLabel.text = string.Format("{0:N0}", score);

            finalGUI.SetActive(true);

            pc.playerState = PlayerState.Dead;

        }
    }
    public void GameOver()
    {
        if (!playEnd)
        {
            Time.timeScale = 0;
            playEnd = true;
            finalMessage.text = "Fail...";
            float score = 1234f - enemyCount * 1234f;
            finalScoreLabel.text = string.Format("{0:N0}", score);
            finalGUI.SetActive(true);

            PlayerController pc = 
                GameObject.Find("PlayerController").GetComponent<PlayerController>();
            pc.playerState = PlayerState.Dead;
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainPlay");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }
}
