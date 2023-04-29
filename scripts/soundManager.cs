using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioClip scoreSoundTemp;
    static public AudioClip scoreSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //scoreSound = Resources.Load<AudioClip>("PingSoundEffect");
        audioSrc = GetComponent<AudioSource>();
        scoreSound = scoreSoundTemp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch(clip)
        {
            case "score":
                audioSrc.PlayOneShot(scoreSound);
                break;
        }
    }
}
