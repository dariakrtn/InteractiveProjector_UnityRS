using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

using UnityEngine.VFX;

public class ControlPanelListener : MonoBehaviour
{
    [SerializeField]
    public Material material;
    private Slider DistStepSlider;
    private TMP_InputField FrInputField;
    private TMP_InputField SpRInputField;
    private Slider RandSlider;
    private Slider PartMinSlider;
    private Slider PartMaxSlider;
    private Slider TurbInSlider;
    private Slider MinDepthRSlider;
    private Slider MaxDepthRSlider;


    [SerializeField]
    private VisualEffect visualEffect;

    [SerializeField]
    private Texture2D defaultTexture;
    [SerializeField]
    private RenderTexture depthTexture;

    public GameObject Canvas;
    public Toggle toggle;

    public float distMinValue;
    public float distMaxValue;
    public float randMinValue;
    public float randMaxValue;

    public float partminMinValue;
    public float partminMaxValue;
    public float partmaxMinValue;
    public float partmaxMaxValue;

    public float mindepthrMinValue;
    public float mindepthrMaxValue;
    public float maxdepthrMinValue;
    public float maxdepthrMaxValue;

    public float turbinMinValue;
    public float turbinMaxValue;

    void Start()
    {
        visualEffect.SetTexture("Render texture", depthTexture);
        DistStepSlider = GameObject.Find("Slider_Distance_Step").GetComponent<Slider>();
        RandSlider = GameObject.Find("Randomness_Slider").GetComponent<Slider>();
        FrInputField = GameObject.Find("InputFieldFrequency").GetComponent<TMP_InputField>();
        SpRInputField = GameObject.Find("InputFieldSpawnRate").GetComponent<TMP_InputField>();
        PartMinSlider = GameObject.Find("ParticleMin_Slider").GetComponent<Slider>();
        PartMaxSlider = GameObject.Find("ParticleMax_Slider").GetComponent<Slider>();
        TurbInSlider = GameObject.Find("TurbulenceInfl_Slider").GetComponent<Slider>();
        MinDepthRSlider = GameObject.Find("MinDepthR_Slider").GetComponent<Slider>();
        MaxDepthRSlider = GameObject.Find("MaxDepthR_Slider").GetComponent<Slider>();

        DistStepSlider.minValue = distMinValue;
        DistStepSlider.maxValue = distMaxValue;
        RandSlider.minValue = randMinValue;
        RandSlider.maxValue = randMaxValue;
        PartMinSlider.minValue = partminMinValue;
        PartMinSlider.maxValue = partminMaxValue;
        PartMaxSlider.minValue = partmaxMinValue;
        PartMaxSlider.maxValue = partmaxMaxValue;

        TurbInSlider.minValue = turbinMinValue;
        TurbInSlider.maxValue = turbinMaxValue;

        MinDepthRSlider.minValue = mindepthrMinValue;
        MinDepthRSlider.maxValue = mindepthrMaxValue;
        MaxDepthRSlider.minValue = maxdepthrMinValue;
        MaxDepthRSlider.maxValue = maxdepthrMaxValue;

        material.SetFloat("_Voronoi_distance_step", 0.5f);
        DistStepSlider.value = 0.5f;
        DistStepSlider.onValueChanged.AddListener(DistStepSliderUpdate);

        material.SetFloat("_Voronoi_Randomness", 0.5f);
        RandSlider.value = 0.5f;
        RandSlider.onValueChanged.AddListener(RandSliderUpdate);

        visualEffect.SetFloat("Particle min size", 0.01f);
        PartMinSlider.value = 0.01f;
        PartMinSlider.onValueChanged.AddListener(PartMinSliderUpdate);

        visualEffect.SetFloat("Particle max size", 0.27f);
        PartMaxSlider.value = 0.27f;
        PartMaxSlider.onValueChanged.AddListener(PartMaxSliderUpdate);

        visualEffect.SetFloat("Turbulence influence", 0.26f);
        TurbInSlider.value = 0.26f;
        TurbInSlider.onValueChanged.AddListener(TurbInSliderUpdate);

        visualEffect.SetFloat("Min range", 0.5f);
        MinDepthRSlider.value = 0.5f;
        MinDepthRSlider.onValueChanged.AddListener(MinDepthRSliderUpdate);

        visualEffect.SetFloat("Max range", 1.5f);
        MaxDepthRSlider.value = 1.5f;
        MaxDepthRSlider.onValueChanged.AddListener(MaxDepthRSliderUpdate);

    }

    void Update()
    {
        string text_fr = FrInputField.text;
        string text_spr = SpRInputField.text;
        if (!(string.IsNullOrEmpty(FrInputField.text)))
        {
            float value_frequency = Single.Parse(text_fr);
            FrequencyUpdate(value_frequency);
        }
        
        if (!(string.IsNullOrEmpty(text_spr)))
        {
            float value_spawnr = Single.Parse(text_spr);
            SpawnRateUpdate(value_spawnr);
        }

    }

    void DistStepSliderUpdate(float value)
    {
        material.SetFloat("_Voronoi_distance_step", value);
    }
    void RandSliderUpdate(float value)
    {
        material.SetFloat("_Voronoi_Randomness", value);
    }
    void FrequencyUpdate(float value)
    {
        material.SetFloat("_Voronoi_Frequency", value);
    }
    void SpawnRateUpdate(float value)
    {
        visualEffect.SetFloat("Spawn rate", value);
    }
    void PartMinSliderUpdate(float value)
    {
        visualEffect.SetFloat("Particle min size", value);
    }
    void PartMaxSliderUpdate(float value)
    {
        visualEffect.SetFloat("Particle max size", value);
    }
    void TurbInSliderUpdate(float value)
    {
        visualEffect.SetFloat("Turbulence influence", value);
    }
    void MinDepthRSliderUpdate(float value)
    {
        visualEffect.SetFloat("Min range", value);
    }
    void MaxDepthRSliderUpdate(float value)
    {
        visualEffect.SetFloat("Max range", value);
    }

    public void onClickHidePanel()
    {
        Canvas.SetActive(false);
    }

    public void onClickOpenPanel()
    {
        Canvas.SetActive(true);
    }
    public void exitApplication()
    {
        Application.Quit();

    }

    public void toggleExampleTrigger()
    {
        //Toggle triggered do something.
        if (toggle.isOn)
            visualEffect.SetTexture("Render texture", depthTexture);
        else
            visualEffect.SetTexture("Render texture", defaultTexture);
    }
}
