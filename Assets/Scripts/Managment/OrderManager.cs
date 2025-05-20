using System.Collections.Generic;
using UnityEngine;

public class OrderManager : Singleton<OrderManager>
{
    public int order = -1;
    public int product = -1;

    public AI_Brain targetClient = null;

    public List<ProductRecipe> productRecipes = new List<ProductRecipe>();

    public SpriteRenderer orderSpawn;


    public bool productReady => product >= 0;

    public void OnLevelWasLoaded(int level)
    {
        orderSpawn = GameObject.FindGameObjectWithTag("OrderSpawn")?.GetComponent<SpriteRenderer>();
    }

    public void SetOrder(int orderID) 
    {
        order = orderID;
    }

    public void SetProduct(ProductRecipe productRecipe) 
    {
        product = productRecipe.id;
        orderSpawn.sprite = productRecipe.sprite;
    }

    public bool GetOrder() 
    {
        if(product == -1 || order == -1) 
        {
            return false;
        }

        if (order == product)
        {
            product = -1;
            order = -1;

            foreach(ProductRecipe recipe in productRecipes) 
            {
                if(recipe.id == product) 
                {
                    PlayerMoney.Instance.AddMoney(recipe.orderPrice);
                }
            }

            orderSpawn.sprite = null;

            return true;
        }

        product = -1;
        order = -1;

        orderSpawn.sprite = null;

        return false;
    }
}
