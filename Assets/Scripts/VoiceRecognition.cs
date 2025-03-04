using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> voiceCommands;
    private VoiceMovementController playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<VoiceMovementController>();

        // Define available voice commands
        voiceCommands = new Dictionary<string, System.Action>
        {
            { "up", () => playerMovement.MovePlayer("up") },
            { "down", () => playerMovement.MovePlayer("down") },
            { "left", () => playerMovement.MovePlayer("left") },
            { "right", () => playerMovement.MovePlayer("right") }
        };

        // Initialize Keyword Recognizer
        keywordRecognizer = new KeywordRecognizer(voiceCommands.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("Heard: " + speech.text);
        voiceCommands[speech.text].Invoke();
    }

    void OnDestroy()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }
}
