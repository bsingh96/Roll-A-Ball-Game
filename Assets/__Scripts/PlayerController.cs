using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float ballSpeed; // declaration of a public variable for the ball speed
    private Rigidbody _rigidBody; // declaration of rigidbody instance to use
    private int _score;// declaration of a private interger variable called count to keep track of the score
    public Text countText;// declaration of an instance of text ui
    public Text restartText;// declaration of an instance of text ui to hold the restarting text
    public GameObject capsule;// declaration of the capsule gameobject
    public GameObject cube;// declaration of the cube gameobject
    public GameObject cylinder;// declaration of the cylinder gameobject
    public float restartDelay = 3f;// declarating and initializing the restart delay of 3f
    public Text winText;

    void Start() // method that is called at the start of the function and initiates the game
    { 
        for (float x = -7; x < 8; x = x + 2)// for loop to create each of the pickup objects in random locations
        {
          
            Instantiate(capsule, new Vector3(x, 1.0f, x), Quaternion.identity);// determines the location of the capsule pickup object
            Instantiate(cube, new Vector3(Random.Range(-9.0f, 9.0f), 1.0f, x+1), Quaternion.identity);// determines the location of the cube pickup object
            Instantiate(cylinder, new Vector3(x, 1.0f,-8.5f), Quaternion.identity);// determines the location of the cylinder pickup object

        }
        _rigidBody = GetComponent<Rigidbody>();// used to access the rigidbody object from unity
        _score = 0;// resets the score to 0 each time
        restartText.text = "";// resets ui text
        winText.text = "";// resets ui text
        SetScore();// calls SetScore
    }

    void FixedUpdate()
    { // function used to track the movement of the ball using the arrow key input and apply the ballSpeed of 10 onto the force applied to move the ball
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 ballMovement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        _rigidBody.AddForce(ballMovement * ballSpeed);
    }

   void OnTriggerEnter(Collider other)// check for which object the player has collided with
        // increment the score by either 1,2,or 3 and make the pickup object dissapear after it is collected
    {
        if (other.gameObject.CompareTag("Pick Up"))// capsule pickup
        {
            other.gameObject.SetActive(false);// set the gameobject to dissapear after it is picked up
            _score = _score + 1;//score increment
            SetScore ();// update score on the screen
        }
     else if (other.gameObject.CompareTag("Pick Up 2"))// cube pickup
        {
            other.gameObject.SetActive(false);// set the gameobject to dissapear after it is picked up
            _score = _score + 2;// score increment
            SetScore ();// update score on the screen
        }
        else // cyclinder pickup
        {
            other.gameObject.SetActive(false);// set the gameobject to dissapear after it is picked up
            _score = _score + 3;// score increment
            SetScore ();// update score on the screen
        }

        }
            
    

    void SetScore() // method used to set the score in the game
    {

        countText.text = "Score:" + _score.ToString();// display the score as the current score based on the pickup collected

        if (_score >= 56)// check if the score is equal to 42 to begin restarting the game
        {
            winText.text = " YOU WIN !!";// sets text to "you win"
            restartText.text = "Restarting........";// sets text to "restarting"
            Invoke("RestartGame", restartDelay);// invokes the RestartGame() function with a set delay of 3f
        }

    }

    void RestartGame()// method to restart the roll a ball game
    {
  
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);// resets the player location to (0,0.5,0)
        _rigidBody.velocity = Vector3.zero;// sets the velocity of the player to 0
        _rigidBody.angularVelocity = Vector3.zero;// sets the angular velocity of the player to 0 so it does not move immediately after restarting.
        Start();// call for Start() to 

    }
}

