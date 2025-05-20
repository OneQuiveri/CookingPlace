using UnityEngine;
using UnityEngine.UI;

public class IngredientToggle : MonoBehaviour
{
    [SerializeField] Image targetImage;

    private CookingPot cookingPot;

    private Ingredient targetIngridient;

    public void Init(CookingPot pot,Ingredient ing) 
    {
        targetImage.sprite = ing.icon;

        cookingPot = pot;
        targetIngridient = ing;
    }

    public void AddIngredient(bool value) 
    {
        if (value) 
        {
            cookingPot.AddIngredientToPot(targetIngridient);
        }
        else 
        {
            cookingPot.RemoveIngredientFromPot(targetIngridient);
        }
    }

}
