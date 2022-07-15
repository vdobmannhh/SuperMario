using UnityEngine;


public class FireFlower : QuestionBlockItem
{
    private  FirstPersonController firstPersonController;
    private Shoot shootScriptHandRight;
    
    protected override void OnStart()
    {
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        shootScriptHandRight = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Shoot>();
    }
    
    protected override void ItemSpecalizedBehavior()
    {
        firstPersonController.PowerUP("Flower");
        shootScriptHandRight.enabled = true;
        
        ChangeUi.setFireflowerDisplay(true);
        ChangeUi.setMushroomDisplay(true);
        gameObject.SetActive(false);
    }
}