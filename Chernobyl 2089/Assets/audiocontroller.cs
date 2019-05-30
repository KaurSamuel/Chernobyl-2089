using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("volume",0.5f);
        audio.volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
