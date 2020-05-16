using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CircleBounce : MonoBehaviour
{
    public int minSpeed;
    public int maxSpeed;
    public float changePosition;
    private GameObject ballOne;
    private GameObject ballTwo;

    private float ballOneSpeed;
    private float ballTwoSpeed;
    
    private string filePath;

    private bool ballOneTransition;
    private bool ballTwoTransition;

    // Start is called before the first frame update
    void Start()
    {
        ballOne = transform.GetChild(0).gameObject;
        ballTwo = transform.GetChild(1).gameObject;

        ballOneSpeed = Random.Range(minSpeed, maxSpeed);
        ballTwoSpeed = Random.Range(minSpeed, maxSpeed);

        filePath = "Speed - " + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".csv";
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeSpeed(ballOne.transform.position.y))
        {
            ballOneSpeed = Random.Range(minSpeed, maxSpeed);
        }

        if (ChangeSpeed(ballTwo.transform.position.y))
        {
            ballTwoSpeed = Random.Range(minSpeed, maxSpeed);
        }
        float BallOnePosition = Mathf.PingPong(Time.time * ballOneSpeed, 10) - 5;
        ballOne.transform.position = new Vector3(ballOne.transform.position.x, BallOnePosition, ballOne.transform.position.z);

        float BallTwoPosition = Mathf.PingPong(Time.time * ballTwoSpeed, 10) - 5;
        ballTwo.transform.position = new Vector3(ballTwo.transform.position.x, BallTwoPosition, ballTwo.transform.position.z);
        //print(ballOneSpeed + ", " + ballTwoSpeed);

    }

    // Save the speeds of the balls to the csv file given in the filepath
    public void SaveBallSpeeds()
    {    
        var first = ballOneSpeed;
        var second = ballTwoSpeed;
        var newLine = string.Format("{0},{1} \n", first, second);
        File.AppendAllText(filePath, newLine);
    }
    
    // Permmit to change the speed of the ball
    public bool ChangeSpeed(float currentPosition)
    {
        print(changePosition - currentPosition);
        
        if (changePosition - currentPosition > 0 && Mathf.Abs(changePosition - currentPosition) < 1)
        {
            return true;
        }
      
        return false;
    }
}
