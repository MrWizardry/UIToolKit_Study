using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIToolKitSc : MonoBehaviour
{
    public VolumeController vC;
    public string itchPedro;
    public string assetsLink;

    public VisualElement menuElement;
    public VisualElement configElement;
    public VisualElement creditsElement;

    //--------Menu--------//
    public Button startButton;
    public Button configButton;
    public Button credButtons;
    public Button quit; 

    //--------Config--------//
    public Button r1;
    public Button r2;
    public Button r3;
    public Button effect;
    public Button returm;

    //--------Credits--------//

    public Button pedro;
    public Button assets;
    public Button voltar;

    void Start()
    {
        //--------Root--------//
        var root = GetComponent<UIDocument>().rootVisualElement;
        //--------Visual Elements--------//
        menuElement = root.Q<VisualElement>("MenuElement");
        configElement = root.Q<VisualElement>("ConfigElement");
        creditsElement = root.Q<VisualElement>("CreditsElement");

        //--------Buttons--------//

            //---MainMenu---//
        startButton = root.Q<Button>("play");
        configButton = root.Q<Button>("config");
        credButtons = root.Q<Button>("credits");
        quit = root.Q<Button>("quit");

            //---Config---//
        effect = root.Q<Button>("PlayEffects");
        r1 = root.Q<Button>("R1");
        r2 = root.Q<Button>("R2");
        r3 = root.Q<Button>("R3");
        returm = root.Q<Button>("ReturnMenu");

            //---Credit---//
        pedro = root.Q<Button>("Pedro");
        assets = root.Q<Button>("Link");
        voltar = root.Q<Button>("Voltar");

        //--------Functioning--------//
            //---MainMenu---//
        startButton.clicked += StartButtonPressed;
        configButton.clicked += ConfigButtonPressed;
        credButtons.clicked += CreditButtonPressed;

           //---Config---//
        r1.clicked += Resolution1Clicked;
        r2.clicked += Resolution2Clicked;
        r3.clicked += Resolution3Clicked;
        effect.clicked += EffectTestButtonClicked;
        returm.clicked += ReturnButtonClicked;
            //---Credit---//
        pedro.clicked += PedroButtonClicked;
        assets.clicked += AssetsButtonClicked;
        voltar.clicked += VoltarButtonClicked;
    }    

    void StartButtonPressed()
    {
        SceneManager.LoadScene("NextScene");
    }
    void ConfigButtonPressed()
    {
        menuElement.style.display = DisplayStyle.None;
        configElement.style.display = DisplayStyle.Flex;
    }
    void CreditButtonPressed()
    {
        menuElement.style.display = DisplayStyle.None;
        creditsElement.style.display = DisplayStyle.Flex;
    }
    void Resolution1Clicked()
    {
        Screen.SetResolution(2560,1440,true);
    }
    void Resolution2Clicked()
    {
        Screen.SetResolution(1920,1080,true);
    }
    void Resolution3Clicked()
    {
        Screen.SetResolution(1280,720,true);
    }
    void EffectTestButtonClicked()
    {
        float effectVolume = vC.effectSlider.value;
        if(effectVolume > 0)
        {
            if(vC.effectAudio != null)
            {
                vC.effectAudio.Play();
            }
        }
        else
            Debug.LogError("Effect volume is zero. No sound will be played.");
    }
    void ReturnButtonClicked()
    {
        menuElement.style.display = DisplayStyle.Flex;
        configElement.style.display = DisplayStyle.None;
    }
    void VoltarButtonClicked()
    {
        menuElement.style.display = DisplayStyle.Flex;
        creditsElement.style.display = DisplayStyle.None;
    }
    void PedroButtonClicked()
    {
        Application.OpenURL(itchPedro);
    }
    void AssetsButtonClicked()
    {
        Application.OpenURL(assetsLink);
    }

}
