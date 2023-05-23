using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Cupid Run/PlayerInventory", order = 0)]
public class PlayerInventory : ScriptableObject
{
    public GameObject[] GoodPlayerModels, EvilPlayerModels, ChangeVFX;
    public string[] GoodSliderTexts, EvilSliderTexts;
    public Sprite[] GoodSliders, EvilSliders;
    public GameObject StartingModel;
    public string ChangeAnimationName;
    public AudioClip TransformSFX;
    [HideInInspector] public string ChangeAnimationString { get { return ChangeAnimationName;}}
}
