﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaEntreEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    private MusicaEntreEscenas instance;
    public AudioClip[] musica;
    public AudioSource audioSource;
    public MusicaEntreEscenas Instance{
        get{
            return instance;
        }
    }
    private void Awake() {
        if(FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }
        if(instance!= null && instance != this){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            audioSource.clip = musica[Random.Range(0,musica.Length)];
            audioSource.Play();
        }
    }
}
