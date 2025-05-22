using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePnanel : MonoBehaviour
{
    public Image ProductImage;

    public Image recipeIngredientImage;

    public Transform recipeIngredietnContainer;

    [SerializeField] List<Image> ingConteiner = new List<Image>();

    public void Init(ProductRecipe recipe) 
    {
        ProductImage.sprite = recipe.sprite;

        foreach(var ing in recipe.recipe) 
        {
            var obj = Instantiate(recipeIngredientImage, recipeIngredietnContainer);
            obj.sprite = ing.icon;

            ingConteiner.Add(obj);
        }
    }
}
