using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider cookingStatus;

    List<Ingredient> existing = new List<Ingredient>();
    List<IngredientToggle> toggles = new List<IngredientToggle>();

    public int maxIngredients = 3;

    [SerializeField] Transform ingredientsConteiner;

    private List<Image> ingredientsSprites = new List<Image>();

    public Image ImageToIng;


    public RecipePnanel recipePanelPrefab;

    public Transform recipePanelConteiner;

    private List<RecipePnanel> recipePanels = new List<RecipePnanel>();

    public Image readyProductImage;

    public Sprite NonProductSprite;

    [SerializeField] AudioSource auidioSource;

    [SerializeField] List<AudioClip> randomClipSounds;
    private void Awake()
    {
        foreach (var recipe in recipes)
        {
            foreach(var ingredient in recipe.recipe) 
            {
                if(existing.Contains(ingredient)) continue;

                existing.Add(ingredient);
                var toggle = Instantiate(ingredientToggle, ingredientToggleConteiner);
                toggle.Init(this, ingredient);

                toggles.Add(toggle);
            }

            var recipeObj = Instantiate(recipePanelPrefab, recipePanelConteiner);
            recipeObj.Init(recipe);
            recipePanels.Add(recipeObj);
        }
    }

    private void Update()
    {
        cookingStatus.value = cookTime;

        if (isCooking) 
        {
            cookTime += Time.deltaTime;

            if (cookTime > maxCookTime) 
            {
                Cook(false);
            }
        }

        CheckProductForPreview();
    }

    public void CheckProductForPreview() 
    {
        OrderManager manager = OrderManager.Instance;

        if (!manager.productReady && readyProductImage.sprite != NonProductSprite) 
        {
            readyProductImage.sprite = NonProductSprite;
        }
        else if (manager.productReady && manager.product == 0 && readyProductImage.sprite != shitProduct.sprite) 
        {
            readyProductImage.sprite = shitProduct.sprite;
        }
        else if (manager.productReady && readyProductImage.sprite == NonProductSprite) 
        {
            readyProductImage.sprite = recipes.Find(x  => x.id == manager.product).sprite;
        }
    }

    public void AddIngredientToPot(Ingredient ing) 
    {
        if (isCooking || IngredientsToCook.Count>=3) return;

        AddIngredientToPotImg(ing);

        IngredientsToCook.Add(ing);
    }

    private void AddIngredientToPotImg(Ingredient ing) 
    {
        var ingImage = Instantiate(ImageToIng, ingredientsConteiner);
        ingImage.sprite = ing.icon;

        ingredientsSprites.Add(ingImage);
    }

    private void RemoveIngredientFromPotImg(Ingredient ing)
    {
        var targetImage = ingredientsSprites.Find(x => x.sprite == ing.icon);


        if (targetImage != null) 
        {
            ingredientsSprites.Remove(targetImage);
            Destroy(targetImage.gameObject);
        }
    }

    public void RemoveIngredientFromPot(Ingredient ing) 
    {
        if (isCooking) return;

        RemoveIngredientFromPotImg(ing);

        IngredientsToCook.Remove(ing);
    }

    public void Cook(bool value)
    {

        if (isCooking && value) return;

        if (!value && !isCooking) return;

        if (OrderManager.Instance.productReady) return;

        if (value && IngredientsToCook.Count == 0)
        {
            return;
        }



        isCooking = value;

        auidioSource.clip = randomClipSounds[Random.Range(0, randomClipSounds.Count)];

        if (value)
        {
            auidioSource.Play();
        }
        else 
        {
            auidioSource.Stop();
        }
            

        Debug.LogError(isCooking ? "Start cook" : "End Cook");

        if (!value) 
        {
            if (cookTime >= validSuccessMinTime && cookTime <= validSuccessMaxTime) 
            {
                var hasValidRecipe = recipes.Find(x => AreIngredientsEqual(x.recipe, IngredientsToCook));

                if (hasValidRecipe != null) 
                {
                    OrderManager.Instance.SetProduct(hasValidRecipe);
                    ClearIngredients();
                    cookTime = 0;
                    return;
                }
            }
            cookTime = 0;
            ClearIngredients();
            OrderManager.Instance.SetProduct(shitProduct);
        }

        cookTime = 0;
    }

    private void ClearIngredients() 
    {
        foreach(var ingImg in ingredientsSprites) 
        {
            Destroy(ingImg.gameObject);
        }
        ingredientsSprites.Clear();
        IngredientsToCook.Clear();


        foreach(var toggle in toggles) 
        {
            toggle.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }
    }

    bool AreIngredientsEqual(List<Ingredient> a, List<Ingredient> b)
    {
        if (a.Count != b.Count)
            return false;

        return !a.Except(b).Any() && !b.Except(a).Any();
    }
}
