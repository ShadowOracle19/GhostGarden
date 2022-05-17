using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    public Elements elements;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Saying something and showing it on the text box
    // function takes two parameters, the dialogue's speaker, and what they are saying 
    public void Say(string speech, string speaker = "")
    {
        StopSpeaking();
        

        speaking = StartCoroutine(Speaking(speech, false, speaker));
    }

    public void SayAdd(string speech, string speaker = "")
    {
        StopSpeaking();
        speechText.text = targetSpeech;

        speaking = StartCoroutine(Speaking(speech, true, speaker));
    }

    //will stop speaking when the dialogue is over
    public void StopSpeaking()
    {
        if(isSpeaking)
        {
            StopCoroutine(speaking);
            
        }
        speaking = null;
    }

    
    //returns true if your character is speaking
    public bool isSpeaking { get{ return speaking != null; } }
    [HideInInspector]public bool waitForInput = false;


    string targetSpeech = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string speech, bool additive, string speaker = "")
    {
        speechpanel.SetActive(true);
        targetSpeech = speech;
        if (!additive)
            speechText.text = "";
        else
            targetSpeech = speechText.text + targetSpeech;

        speakerName.text = DetermineSpeaker(speaker);
        waitForInput = false;

        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        //text finished
        waitForInput = true;
        while (waitForInput)
        {
            yield return new WaitForEndOfFrame();
        }

        StopSpeaking();
    }    

    //In this function seperates the speaker from the speech using a colon. The "s" parameter it takes is the Speaker of the dialogue.
    string DetermineSpeaker(string s)
    {
        string retVal = speakerName.text; //default return is the last speaker

        if (s != speakerName.text && s!= "")
            retVal = (s.ToLower().Contains("narrator")) ? "" : s;

        return retVal;
    }

    //this turns the UI off once the speech is over
    public void Close()
    {
        StopSpeaking();
        speechpanel.SetActive(false);
    }

    [System.Serializable]
    public class Elements
   {
        //this class contains any elements related to dialogue. It can all be found in the UI.
        public GameObject speechPanel;
        public Text speaker;
        public Text speechText;
   }

    //this references the elements class so that they can be accessed by the DialogueSystem class
    public GameObject speechpanel { get{ return elements.speechPanel; } }
    public Text speakerName { get { return elements.speaker; } }
    public Text speechText { get { return elements.speechText; } }
}
