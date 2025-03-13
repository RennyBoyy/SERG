using UnityEngine;
using UnityEngine.Android;

public class VoiceRecognition : MonoBehaviour
{
    public static VoiceRecognition Instance;
    private AudioClip audioClip;
    private const int sampleRate = 44100;
    private bool isRecording = false;
    private float[] audioData;
    private int sampleLength = 1024;
    public float threshold = 0.05f;
    public Fire Fire;
    public float shootCooldown = 1f;
    private float nextShootTime = 0f;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioData = new float[sampleLength];

        // Request microphone permission at runtime
        RequestMicrophonePermission();
    }

    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            StartRecording();
        }
        else
        {
            Debug.LogWarning("Microphone permission not granted. Waiting for user permission.");
        }
    }

    void RequestMicrophonePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    private void StartRecording()
    {
        if (!Microphone.IsRecording(null))
        {
            audioClip = Microphone.Start(null, true, 1, sampleRate);
            isRecording = true;
            Debug.Log("Microphone recording started.");
        }
    }

    void Update()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.LogWarning("Microphone permission is still not granted.");
            return;
        }

        if (isRecording && Microphone.IsRecording(null))
        {
            int micPosition = Microphone.GetPosition(null);
            if (micPosition < sampleLength) return;

            audioClip.GetData(audioData, micPosition - sampleLength);

            if (IsSoundDetected() && Time.time > nextShootTime)
            {
                Fire.Shoot();
                nextShootTime = Time.time + shootCooldown;
            }
        }
    }

    private bool IsSoundDetected()
    {
        float sum = 0;
        for (int i = 0; i < audioData.Length; i++)
        {
            sum += Mathf.Abs(audioData[i]);
        }

        float averageVolume = sum / audioData.Length;
        return averageVolume > threshold;
    }

}