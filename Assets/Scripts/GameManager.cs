using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource playerAudioSource1;
    public AudioSource playerAudioSource2;

    public AudioClip neathDarkWaters;
    public AudioClip mortalInstants;
    public AudioClip emetLines;

    public GameObject light1;
    public GameObject light2;

    MeteorSpawner spawner;

    enum GameState {chill, uhoh}
    GameState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.chill;
        spawner = FindObjectOfType<MeteorSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.chill:
            playerAudioSource1.Pause();
            if (playerAudioSource1.isPlaying == false)
            {
                currentState = GameState.uhoh;
                playerAudioSource1.clip = mortalInstants;
                playerAudioSource1.Play();
                playerAudioSource1.loop = true;
                playerAudioSource2.clip = emetLines;
                playerAudioSource2.Play();
                spawner.shouldSpawn = true;
                light1.gameObject.SetActive(false);
                light2.gameObject.SetActive(true);
            }
            break;
        }
    }
}
