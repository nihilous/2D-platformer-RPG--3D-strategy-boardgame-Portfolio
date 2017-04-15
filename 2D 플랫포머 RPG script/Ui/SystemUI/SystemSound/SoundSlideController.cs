using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSlideController : MonoBehaviour {

   public Slider volumeControlSlider;
   public List<AudioSource> audioVolume = new List<AudioSource>();

    public void SlideVolumeControl()
    {

        if (gameObject.name == "FXSlider")
        { 
            if(audioVolume.Count==0)
            {
                AudioSource[] playerFx = GameObject.Find("Player").GetComponents<AudioSource>();
                AudioSource[] foreignFx = GameObject.Find("ForeignSoundManager").GetComponents<AudioSource>();
                for (int i = 0; i < playerFx.Length; i++)
                {
                    audioVolume.Add(playerFx[i]);
                }
                for (int i = 0; i < foreignFx.Length; i++)
                {
                    audioVolume.Add(foreignFx[i]);
                }
                for (int i = 0; i < audioVolume.Count; i++)
                {

                    audioVolume[i].volume = volumeControlSlider.value;
                }
            }
            else if (audioVolume.Count==19)
            { 
            for (int i = 0; i < audioVolume.Count; i++)
            {

                audioVolume[i].volume = volumeControlSlider.value;
            }
            }
            Debug.Log(audioVolume.Count);
        
        }
        else if (gameObject.name == "BGMSlider")
        {
            for (int i = 0; i < audioVolume.Count; i++)
            {

                audioVolume[i].volume = volumeControlSlider.value;
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
