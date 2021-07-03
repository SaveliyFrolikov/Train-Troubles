using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool about;
    [SerializeField] GameObject aboutImg, aboutImg2;

    [SerializeField]AudioSource audioSource;

    [SerializeField] Slider sfxSlider, musicSlider;
    [SerializeField] TextMeshProUGUI sfxPercent, musicPercent;

    AudioSource[] sounds;
    AudioSource musicSource;

    void Start()
    {
        about = false;
        musicSource = GetComponent<AudioSource>();
        sounds = FindObjectsOfType<AudioSource>().Where(f => f.GetInstanceID() != gameObject.GetInstanceID()).ToArray();

        LoadVolume();
        musicSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
    }

    
    void Update()
    {
        if (about)
        {
            aboutImg.GetComponent<Animator>().SetBool("fly", true);
            aboutImg2.GetComponent<Animator>().SetBool("fly", true);
        }
        else
        {
            aboutImg.GetComponent<Animator>().SetBool("fly", false);
            aboutImg2.GetComponent<Animator>().SetBool("fly", false);
        }

        
    }

    public void About()
    {
        about = !about;
        aboutImg.GetComponent<AudioSource>().Play();
        aboutImg2.GetComponent<AudioSource>().Play();
    }

    public void Btn()
    {
        audioSource.Play();
    }

    void UpdateVolume()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].volume = sfxSlider.value;
        }

        musicSource.volume = musicSlider.value;

        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);

        sfxPercent.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();
        musicPercent.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
    }

    void LoadVolume()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].volume = PlayerPrefs.GetFloat("SFX", 0.5f);
        }

        musicSource.volume = PlayerPrefs.GetFloat("Music", 0.5f);

        musicSlider.value = musicSource.volume;
        sfxSlider.value = sounds[1].volume;

        sfxPercent.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();
        musicPercent.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void LoadNextScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
