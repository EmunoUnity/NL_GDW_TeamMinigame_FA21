using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 60f;
    public Text timerSeconds;

    public GameObject car1Drive;

    public GameObject car2Drive;

    public Image line;

    public Camera MainCamera;

    public GameObject player1;

    public GameObject player2;

    public GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        timerSeconds = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f2");
        if (timer <= 0)
        {
            Instantiate(car1Drive, car1Drive.transform.position, car1Drive.transform.rotation);
            Instantiate(car2Drive, car2Drive.transform.position, car2Drive.transform.rotation);
            Destroy(player2);
            Destroy(player1);
            Destroy(spawnManager);
            MainCamera.enabled = false;
            timerSeconds.enabled = false;
            line.enabled = true;
            timer = 100000000000000f;
        }
    }
}
