using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockItems : MonoBehaviour
{
    public enum QuestionBlockItemType 
    {
        Coin, 
        MushroomSizeUp, 
        MushroomLifeUp,
        Fire,
        Star
    };
    
    public GameObject coin;
    public GameObject mushroomSizeUp;
    public GameObject mushroomLifeUp;
    public GameObject fire;
    public GameObject star;
    
    private static GameObject prefabCoin;
    private static GameObject prefabMushroomSizeUp;
    private static GameObject prefabMushroomLifeUp;
    private static GameObject prefabFire;
    private static GameObject prefabStar;
    
    // Start is called before the first frame update
    void Start()
    {
        prefabCoin = coin;
        prefabMushroomSizeUp = mushroomSizeUp;
        prefabMushroomLifeUp = mushroomLifeUp;
        prefabFire = fire;
        prefabStar = star;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject GetItemPrefab(QuestionBlockItemType type)
    {
        switch (type)
        {
            case QuestionBlockItemType.Coin:
                return prefabCoin;
            case QuestionBlockItemType.MushroomSizeUp:
                return prefabMushroomSizeUp;
            case QuestionBlockItemType.MushroomLifeUp:
                return prefabMushroomLifeUp;
            case QuestionBlockItemType.Fire:
                return prefabFire;
            case QuestionBlockItemType.Star:
                return prefabStar;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
