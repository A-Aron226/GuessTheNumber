using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GuessNumber : MonoBehaviour
{
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_InputField input;
    int guessNumber;
    int attempts;
    // Start is called before the first frame update
    void Start()
    {
        ResetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Button ButtonSubmit; //accesses the ButtonSubmit from the hierarchy
    
    public void ChangeText() //SubmitGuess method
    {
        int userInput = int.Parse(input.text);
        if (userInput != guessNumber)
        {
            attempts = attempts - 1; //subracts attempts by 1 if the user number does not match the bots chosen number.
                                     //Having it as '-=' caused the attempt number to go negative for some reason
            header.text = "Incorrect! you have " + attempts + " left.";
        }

        if (userInput == guessNumber)
        {
            header.text = "You guessed the number Correctly! Restart to replay the game.";
            ButtonSubmit.enabled = false; //disables Submit button once the user correctly guesses the bot's chosen number
        }

        if (attempts == 0)
        {
            header.text = "No attempts left. Restart to try again.";
            ButtonSubmit.enabled = false; //disables submit button once the user attempts reaches zero. Makes it so attempt number does not go below zero.
        }

        if (string.IsNullOrEmpty(input.text))
        {
            ButtonSubmit.enabled = false; //will keep submit button disabled if text field is empty
        }
    }

    public void ResetText() //GameSetup method. Acts as a reset button to start from the beginning
    {
        input.text = "";
        header.text = "Guess the number Between 1 and 10. You have 3 attempts.";
        attempts = 3; //starter user attempts
        guessNumber = Random.Range(1, 11);//The number the bot chooses for the player to guess
        ButtonSubmit.enabled = true;
    }
}
