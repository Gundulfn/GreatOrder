using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IngredientInfo", order = 1)]
public class IngredientInfo : ScriptableObject
{
    public Sprite ingredientImg;
    public string ingredientName;
    public int price;
}
