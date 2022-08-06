using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHandler : MonoBehaviour
{

    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData.volume = GameManagement.globalMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
