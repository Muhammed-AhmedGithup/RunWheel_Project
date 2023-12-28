using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameover_panel;
    public static bool isGamestart;
    public GameObject start_text;
    public static int numberofcoins;
    public TextMeshProUGUI textCoin;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Time.timeScale = 1.0f;
        isGamestart = false;
        numberofcoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameover_panel.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isGamestart = true;
            
            start_text.SetActive(false);
           
        }
        textCoin.text = "Coins: " + numberofcoins.ToString();


    }

}
