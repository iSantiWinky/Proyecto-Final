using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private CountDownTimer timer;


    private void Start()
    {
        timer = gameObject.GetComponent<CountDownTimer>();
        timer.StartTimer();
    }

    public void EndGame()
    {
        timer.StopTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
