using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class new_event2 : MonoBehaviour {

    public GameObject player = null;
    public GameObject myo = null;
    public GameObject canvas = null;
    public GameObject AI = null;
    public GameObject effect = null;
    //public GameObject systemthis = null;
    public static int lv =1;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

            effect.SetActive(true);
  
            lv = ScoreManager.level;
	}
}
