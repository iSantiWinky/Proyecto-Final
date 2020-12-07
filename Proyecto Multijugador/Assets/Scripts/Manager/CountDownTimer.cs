using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    private int m, s;

    [SerializeField]
    private Text timerText;

    private GameControl gameControl;

    private void Start()
    {
        gameControl = gameObject.GetComponent<GameControl>();
    }

    public void StartTimer()
    {
        m = minutes;
        s = seconds;
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    public void StopTimer()
    {
        CancelInvoke();
    }

    public void UpdateTimer()
    {
        s--;
        if(s < 0)
        {
            if(m == 0)
            {
                gameControl.EndGame();
                return;
            }
            else
            {
                m--;
                s = 59;
            }
        }

        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    private void WriteTimer(int m, int s)
    {
        if(s < 15)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }
}
