using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Stove : MonoBehaviour, IPutItemFull
{
    private enum Conditions
    {
        IsCooking,
        Cooked,
        Burning

    }

    private Conditions conditions;


    #region Serialize Variables
    [Header("Meatball Types")]
    [SerializeField] private GameObject meatballOvenObject;
    [SerializeField] private GameObject meatballCookedObject;
    [SerializeField] private GameObject meatballBurnedObject;

    [Header("Slider Values")]
    [SerializeField] private Color32 burningColor;
    [SerializeField] private Color32 cookingColor;
    [SerializeField] private Slider cookSlider;
    [SerializeField] private int sliderMaxValue;
    #endregion


    private ItemType meatType;
    private bool isCooking;
    private bool isMeatballReady;
    private RectTransform fillRect;
    private float sliderValue;
    private void Start()
    {
        fillRect = cookSlider.fillRect;
        cookSlider.maxValue = sliderMaxValue;
        StoveEmptyStatus();
        conditions = Conditions.IsCooking;
        meatType = ItemType.NONE;

    }

    public void ClearItemType()
    {
        meatType = ItemType.NONE;
        if (isMeatballReady)
        {
            StoveEmptyStatus();
        }
    }

    public ItemType GetCurrentItem()
    {
        return meatType;
    }


    private void Update()
    {
        if (!isCooking) return;
        ProcessItem();
    }
    public void ProcessItem()
    {
        switch (conditions)
        {
            case Conditions.IsCooking:
                sliderValue += 0.1f;
                cookSlider.value = sliderValue;
                if (sliderValue>=sliderMaxValue)
                {
                    conditions = Conditions.Cooked;
                    sliderValue = 0;
                    MeatballCooked();
                    isMeatballReady = true;
                    meatType = ItemType.COOKED_MEAT;

                }
                break;
            case Conditions.Cooked:
                sliderValue += 0.15f;
                cookSlider.value = sliderValue;
                fillRect.GetComponent<Image>().color = burningColor;
                if (sliderValue >= sliderMaxValue)
                {
                    conditions = Conditions.Burning;
                    sliderValue = 0;
                    MeatballBurned();
                    isMeatballReady = false;
                    meatType = ItemType.NONE;
                }
                break;
            case Conditions.Burning:
                StoveEmptyStatus();
                ClearItemType();
                break;
        }
    }

    public bool PutItem(ItemType itemType)
    {
        if (itemType != ItemType.MEATBALL) return false;
        isCooking = true;
        StoveIsWorking();
        return true;
        
    }

    private void StoveEmptyStatus()
    {
        cookSlider.gameObject.SetActive(false);
        isCooking = false;
        conditions = Conditions.IsCooking;
        meatballOvenObject.SetActive(false);
        meatballCookedObject.SetActive(false);
        fillRect.GetComponent<Image>().color = cookingColor;
    }

    private void StoveIsWorking()
    {
        cookSlider.gameObject.SetActive(true);
        isCooking = true;
        meatballOvenObject.SetActive(true);
        meatballBurnedObject.SetActive(false);
    }

    private void MeatballCooked()
    {
        meatballCookedObject.SetActive(true);
        meatballOvenObject.SetActive(false);
    }

    private void MeatballBurned()
    {
        meatballBurnedObject.SetActive(true);
        meatballCookedObject.SetActive(false);

        Invoke(nameof(DestroyingBurntMeatballs), 1f);
    }

    private void DestroyingBurntMeatballs()
    {
        meatballBurnedObject.SetActive(false);
    }
}
