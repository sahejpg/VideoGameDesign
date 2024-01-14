using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrollTextScript : MonoBehaviour
{
    public GameObject bossText1;
    public GameObject bossText2;
    public GameObject bossText3;
    public GameObject scrollTextButton;


    // Start is called before the first frame update
    void Start()
    {
        // bossText1 = GameObject.Find("bossText1");
        // bossText2 = GameObject.Find("bossText2");
        // bossText3 = GameObject.Find("bossText3");
        // scrollTextButton = GameObject.Find("scrollTextButton");
    }


    // Update is called once per frame
    void Update()
    {


    }


    public void textScroll()
    {
        bossText1.SetActive(false);
        bossText2.SetActive(false);
        bossText3.SetActive(false);
        scrollTextButton.SetActive(false);
        Time.timeScale = 1f;
    }
}
