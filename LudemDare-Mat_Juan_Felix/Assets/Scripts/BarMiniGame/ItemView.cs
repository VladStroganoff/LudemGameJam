using ProjectName.MiniGames.Bar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    public Transform hand;
    public GameObject pinkDrink;
    public GameObject blueDrink;
    public GameObject grenDrink;
    public GameObject redDrink;

    public GameObject currentDrink;

    Vector3 position = new Vector3(-0.208f, 0.006f, 0.178f);
    Vector3 rotation = new Vector3(215.945f, 133.653f, -13.14899f);


    private void Start()
    {
        StartCoroutine(BabysitHeldItem());  
    }


    public void SetItem(DrinkRecipe.Ingredient ingredient)
    {
        if (currentDrink != null)
            RemoveFromHand();


        switch (ingredient)
            {
            case DrinkRecipe.Ingredient.Blue:
                currentDrink = Instantiate(blueDrink, hand.position,hand.rotation, hand);
                break;
            case DrinkRecipe.Ingredient.Pink:
                currentDrink = Instantiate(pinkDrink, hand.position, hand.rotation, hand);
                break;
            case DrinkRecipe.Ingredient.Red:
                currentDrink = Instantiate(redDrink, hand.position, hand.rotation, hand);
                break;
            case DrinkRecipe.Ingredient.Green:
                currentDrink = Instantiate(grenDrink, hand.position, hand.rotation, hand);
                break;
        }

        currentDrink.transform.position = Vector3.zero;

    }


    IEnumerator BabysitHeldItem()
    {
        while (true)
        {
            if (currentDrink != null)
            {
                currentDrink.transform.localPosition = position;
                currentDrink.transform.rotation = Quaternion.Euler(rotation);
            }

            yield return new WaitForEndOfFrame();
        }


        yield return null;
    }


    public void RemoveFromHand()
    {
        Destroy(currentDrink);
    }

}
