using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductRecipe", menuName = "Scriptable Objects/ProductRecipe")]
public class ProductRecipe : ScriptableObject
{
    public int id => emotion.orderID;

    public Sprite sprite => emotion.emotionSprite;

    public OrderEmotion emotion;

    public List<Ingredient> recipe = new List<Ingredient>();

    public int orderPrice = 25;
}
