using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private TMP_Text locationText;  // Reference to the location text

    [SerializeField]
    private Image portraitImage;

    [SerializeField]
    private Image backgroundImage;  // Reference to the background image

    [SerializeField]
    private Image locationImage;  // Reference to the location image

    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    [SerializeField]
    private Sprite[] locationBox;  // Array of location box sprites

    [SerializeField]
    private Sprite[] backgrounds;  // Array of background sprites

    [SerializeField]
    private string[] locations;  // Array of location names

    private int step = 0;
    private bool isKeyProcessed = false;

    // Update is called once per frame
    void Update()
    {
        // Detect space key press for advancing
        if (Input.GetKeyDown(KeyCode.Space) && !isKeyProcessed)
        {
            isKeyProcessed = true;
            AdvanceDialogue();
        }

        // Detect left arrow key press for rewinding
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isKeyProcessed)
        {
            isKeyProcessed = true;
            RewindDialogue();
        }

        // Reset key press detection
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isKeyProcessed = false;
        }
    }

    private void AdvanceDialogue()
    {
        if (step < speaker.Length && step < dialogueWords.Length)
        {
            // Update the dialogue and speaker
            UpdateDialogueStep();

            // Increment the step to move to the next dialogue
            step++;
        }
        else
        {
            // Optionally handle the end of the dialogue
            Debug.Log("Dialogue finished");
            // Reset step if you want to loop the dialogue
            // step = 0;
        }
    }

    private void RewindDialogue()
    {
        if (step > 0)
        {
            // Decrement the step to move to the previous dialogue
            step--;

            // Update the dialogue and speaker
            UpdateDialogueStep();
        }
        else
        {
            // Optionally handle the start of the dialogue
            Debug.Log("At the beginning of the dialogue");
        }
    }

    private void UpdateDialogueStep()
    {
        // Update the dialogue and speaker
        speakerText.text = speaker[step];
        dialogueText.text = dialogueWords[step];

        // Check if there is a corresponding portrait sprite
        if (step < portrait.Length)
        {
            portraitImage.sprite = portrait[step];
            portraitImage.gameObject.SetActive(true);
        }
        else
        {
            // If no portrait sprite is available, hide the portrait image
            portraitImage.gameObject.SetActive(false);
        }

        // Check if there is a corresponding background sprite
        if (step < backgrounds.Length)
        {
            backgroundImage.sprite = backgrounds[step];
            backgroundImage.gameObject.SetActive(true);
        }
        else
        {
            // Optionally handle no background sprite case
            backgroundImage.gameObject.SetActive(false);
        }

        // Check if there is a corresponding location name
        if (step < locations.Length)
        {
            locationText.text = locations[step];
            locationText.gameObject.SetActive(true);
        }
        else
        {
            // Optionally handle no location name case
            locationText.gameObject.SetActive(false);
        }

        // Check if there is a corresponding location box sprite
        if (step < locationBox.Length)
        {
            locationImage.sprite = locationBox[step];
            locationImage.gameObject.SetActive(true);
        }
        else
        {
            // Optionally handle no location box sprite case
            locationImage.gameObject.SetActive(false);
        }

        // Log current step for debugging
        Debug.Log($"Step: {step}, Speaker: {speaker[step]}, Dialogue: {dialogueWords[step]}, Location: {(step < locations.Length ? locations[step] : "N/A")}");
    }
}
