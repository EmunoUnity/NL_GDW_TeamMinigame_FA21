using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScenarion : MonoBehaviour
{
    public bool Player1Wins;

    public bool Player2Wins;

    public bool deciding = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") && deciding == true)
        {
            Player1Wins = true;
            deciding = false;
            Debug.Log("Player 1 Wins!");
        }

        if(collision.gameObject.CompareTag("Player2") && deciding == true)
        {
            Player2Wins = true;
            deciding = false;
            Debug.Log("Player 2 Wins!");
        }
    }
}
