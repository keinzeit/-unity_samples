using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;

    // static reference to the current AudioManager that we have on our scene
    // (static means that all instances of AudioManager will share the same value
    // for that field)
    public static AudioManager instance;

    void Awake()
    {
        // singleton design: only allows one copy of AudioManager in the game
        if (instance == null) // if we don't have an AudioManager in our scene
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            // where does this AudioSource come from?
            // does this just set up the AudioSource for each Sound?
            // because each sound you play needs to be played from an AudioSource
            // that's attached to a GameObject
            // --> oohh ok, so the AudioManager sets up the AudioSource for each
            // AudioClip that you want to play, and the GameObject to which all
            // these AudioSources are attached to is the AudioManager GameObject
            // --> so the sounds you initialize in the AudioManager aren't tied
            // to other objects
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound <" + name + "> not found!");
            return;
        }

        s.source.Play();

    }
}
