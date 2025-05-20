using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CookingPot : MonoBehaviour
{
    public const float maxCookTime = 30f;

    public const float validSuccessMinTime = 10;
    public const float validSuccessMaxTime = 20;

    public List<Ingredient> IngredientsToCook = new List<Ingredient>();

    [SerializeField] private List<ProductRecipe> recipes = new List<ProductRecipe>();

    private bool isCooking = false;

    public bool IsCooking => isCooking;

    private float cookTime = 0;

    public ProductRecipe shitProduct;

    [SerializeField] IngredientToggle ingredientToggle;

    [SerializeField] Transform ingredientToggleConteiner;


    private void Awake()
    {
        foreach (var recipe in recipes)
        {
            foreach(var ingredient in recipe.recipe) 
            {
                var toggle = Instantiate(ingredientToggle, ingredientToggleConteiner);
                toggle.Init(this, ingredient);
            }
        }
    }

    private void Update()
    {
        if (isCooking) 
        {
            cookTime += Time.deltaTime;

            if (cookTime > maxCookTime) 
            {
                Cook(false);
            }
        }
    }

    public void AddIngredientToPot(Ingredient ing) 
    {
        if (isCooking) return;
        IngredientsToCook.Add(ing);
    }

    public void RemoveIngredientFromPot(Ingredient ing) 
    {
        if (isCooking) return;
        IngredientsToCook.Remove(ing);
    }

    public void Cook(bool value) 
    {
        if (isCooking && value) return;

        if(OrderManager.Instance.productReady) return;

        if (value && IngredientsToCook.Count == 0)
        {
            return;
        }



        isCooking = value;

        Debug.LogError(isCooking ? "Start cook" : "End Cook");

        if (!value) 
        {
            if (cookTime >= validSuccessMinTime && cookTime <= validSuccessMaxTime) 
            {
                var hasValidRecipe = recipes.Find(x => AreIngredientsEqual(x.recipe, IngredientsToCook));

                if (hasValidRecipe != null) 
                {
                    OrderManager.Instance.SetProduct(hasValidRecipe);
                    cookTime = 0;
                    return;
                }
            }
            cookTime = 0;
            OrderManager.Instance.SetProduct(shitProduct);
        }

        cookTime = 0;
    }

    bool AreIngredientsEqual(List<Ingredient> a, List<Ingredient> b)
    {
        if (a.Count != b.Count)
            return false;

        return !a.Except(b).Any() && !b.Except(a).Any();
    }
}
