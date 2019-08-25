using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    public float TotalCountDownTime;
    public float TotalGOTime;
    public float PositionAdjustmenWithGo;

    public GameObject Player1;
    public GameObject Player2;
    public Text countDownText;
    public bool start = false;

    float currentTime;
    bool countingDown;
    
    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }

    public void startCountDown()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        countingDown = true;
        currentTime = TotalCountDownTime;
        countDownText.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current timer time = " + currentTime.ToString());
        if (countingDown && currentTime <= 1)
        {
            countingDown = false;
            currentTime = 0.0F;
            countDownText.text = "GO";
            countDownText.transform.position = new Vector3(countDownText.transform.position.x + PositionAdjustmenWithGo, countDownText.transform.position.y, countDownText.transform.position.z); ;
        }

        if (countingDown)
        {
            //countDown
            currentTime -= 1 * Time.deltaTime;
            int textInt = (int)currentTime;
            countDownText.text = textInt.ToString();
        }
        else
        {
            //if not counting down, we display the "GO" text for some time 
            currentTime += 1 * Time.deltaTime;
            if(currentTime >= TotalGOTime)
            {
                //when done displaying "GO" text, dissapear
                countDownText.enabled = false;
                Player1.SetActive(true);
                Player2.SetActive(true);
                start = true;
            }
        }
    }
}
