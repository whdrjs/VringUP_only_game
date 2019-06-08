using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GazeInteraction : MonoBehaviour
{
    public Text text = null;
    public int start = 0;
    public int manager = 0;
    public float gazeTime = 3f;
    private float timer;
    private bool gazedAt;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                // execute pointerdown handler
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
            /*
            if(manager==1){
                SceneManager.LoadScene("test1");
            }
            else if(manager==2){
                SceneManager.LoadScene("game_test");
            }
            */
        }

    }

    public void PointerEnter()
    {
        gazedAt = true;
        Debug.Log("PointerEnter");
    }

    public void PointerExit()
    {
        gazedAt = false;
        Debug.Log("PointerExit");
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown");
    }


    public void OnClickTest()
    {
        start++;
        PlayerPrefs.SetInt("flag", start);
        gazedAt = true;
//        manager = 1;
        SceneManager.LoadScene("test1");
    }
    public void OnClickGame()
    {
        PlayerPrefs.GetInt("flag");
        //SceneManager.LoadScene("game_test");
        if (start > 0)
        {
   //         manager = 2;
            SceneManager.LoadScene("game_test");
            PlayerPrefs.DeleteAll();
        }
        else
        {
            text.GetComponent<Text>().text = "측정하기를 먼저 진행하세요";
        }
    }

}