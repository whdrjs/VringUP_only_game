using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager SMi;
    public Text scoreText;
    public static int level=9;
    public static int score = 8;
    private int check = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        if (!SMi)
            SMi = this;
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (SceneManager.GetActiveScene().buildIndex == 4&&check==0)
        {
            level = 9;
            score = 0;
            check++;
        }*/
	}
}
