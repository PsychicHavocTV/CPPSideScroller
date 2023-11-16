using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/ShopItem", order = 1)]
public class ShopItems : ScriptableObject
{
    public RawImage icon;
    public string itemName = "";
    public string itemDescription = "";
    public int itemPrice = 0;

    public bool cosmetic = false;
}
