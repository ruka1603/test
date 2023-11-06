using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public bool playEnd;
    public float limitTime;
    public int enemyCount;

    public Text timeLabel;
    public Text enemyLabel;

    private void Start()
    {
        enemyLabel.text = string.Format("Enemy : {0}", enemyCount);
        timeLabel.text = string.Format("Time : {0}", limitTime);
    }

    private void Update()
    {
        if (limitTime > 0)
        {
            limitTime -= Time.deltaTime;
            timeLabel.text = string.Format("Time : {0:N2}", limitTime);
        }
    }
}
