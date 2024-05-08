using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor.ShaderGraph.Internal;
using System;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    [SerializeField] Toggle fullscreenToggle;
    Resolution[] resolutions;

    [Header("Postprocessing")]
    [SerializeField] Slider bloomSlider;
    [SerializeField] Volume volume;
    [SerializeField] Bloom bloom;

    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat ("SFXVolume");
        GetResolutionOptions();
        GetEffects();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            ToggleOptions();
        }
        
    }

    public void SetMasterVolume(){
        audioMixer.SetFloat("MasterVolume",ConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("MasterVolume",masterVolumeSlider.value);
    }

    public void SetMusicVolume(){
        audioMixer.SetFloat("MusicVolume",ConvertToDec(musicVolumeSlider.value));
        PlayerPrefs.SetFloat("MusicVolume",musicVolumeSlider.value);
    }

    public void SetSFXVolume() {
        audioMixer.SetFloat("SFXVolume",ConvertToDec(sfxVolumeSlider.value));
        PlayerPrefs.SetFloat("SFXVolume",sfxVolumeSlider.value);
    }

    float ConvertToDec(float sliderValue){
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    void GetResolutionOptions() {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for(int i = 0; i<resolutions.Length; i++){
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void ChooseResolution(){
        Screen.SetResolution(resolutions[resDropdown.value].width,resolutions[resDropdown.value].height,fullscreenToggle.isOn);
    }

    public void GetEffects(){
        if(volume.profile.TryGet(out Bloom newBloom)) {
            bloom = newBloom;   
        }
    }

    public void SetBloom(){
        bloom.intensity.value = bloomSlider.value;
    }

    public void OpenOptions(){
        canvas.enabled = true;
    }

    public void CloseOptions(){
        canvas.enabled = false;
    }

    void ToggleOptions(){
        canvas.enabled = !canvas.enabled;
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
