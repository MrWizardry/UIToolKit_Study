using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider effectSlider;
    public AudioMixer audioMixer;
    public AudioSource effectAudio;

    private const string musicVolumeParameter = "BGM";
    private const string effectVolumeParameter = "Effect";

    void Start()
    {
        setInitialVolume();
    }

    void setInitialVolume()
    {
        float initialMusicVolume = volumeSlider.value;
        float initialEffectVolume = effectSlider.value;

        audioMixer.SetFloat(musicVolumeParameter,Mathf.Log10(initialMusicVolume)* 20);
        audioMixer.SetFloat(effectVolumeParameter, Mathf.Log10(initialEffectVolume) * 20);
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        volumeSlider = root.Q<Slider>("Volume");
        volumeSlider.RegisterCallback<ChangeEvent<float>>(OnMusicVolumeChanged);

        effectSlider = root.Q<Slider>("Effects");
        effectSlider.RegisterCallback<ChangeEvent<float>>(OnEffectVolumeChanged);

        
    }

    void OnMusicVolumeChanged(ChangeEvent<float> evt)
    {
        Debug.Log("Volume Changed to: " + evt.newValue);
        audioMixer.SetFloat(musicVolumeParameter, Mathf.Log10(evt.newValue)*20);
    }
    void OnEffectVolumeChanged(ChangeEvent<float> evt)
    {
        Debug.Log("Effect Volume: " + evt.newValue);
        audioMixer.SetFloat(effectVolumeParameter, Mathf.Log10(evt.newValue)*20);

        if(effectAudio != null)
        {
            effectAudio.volume = evt.newValue;
        }
    }

}
