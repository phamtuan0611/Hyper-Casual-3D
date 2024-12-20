using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticsButtonImage;

    [Header(" Settings ")]
    private bool soundsState = true;
    private bool hapticsState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        //hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Setup()
    {
        if (soundsState)
            EnableSounds();
        else
            DisableSounds();

        if (hapticsState)
            EnableHaptics();
        else
            DisableHaptics();
    }

    public void ChangeSoundsState()
    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();

        soundsState = !soundsState;

        PlayerPrefs.SetInt("sounds", soundsState  ? 1 : 0);
    }

    private void DisableSounds()
    {
        soundsManager.DisableSounds();

        soundsButtonImage.sprite = optionOffSprite;
    }

    private void EnableSounds()
    {
        soundsManager.EnableSounds();

        soundsButtonImage.sprite = optionsOnSprite;
    }

    public void ChangeHapticsState()
    {
        if (hapticsState)
            DisableHaptics();
        else
            EnableHaptics();

        hapticsState = !hapticsState;

        //PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);
    }

    private void DisableHaptics()
    {
        //hapticsManager.DisableSounds();

        hapticsButtonImage.sprite = optionOffSprite;
    }

    private void EnableHaptics()
    {
        //hapticsManager.EnableSounds();

        hapticsButtonImage.sprite = optionsOnSprite;
    }
}
