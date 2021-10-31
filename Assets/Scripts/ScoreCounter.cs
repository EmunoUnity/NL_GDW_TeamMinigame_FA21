using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text txt;

    public Text txt2;

    public float score;

    public float score2;



    // Start is called before the first frame update

  
    void Start()
    {
        txt.text = score.ToString();
        txt2.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = score.ToString();
        txt2.text = score2.ToString();
    }
}
