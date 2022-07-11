using UnityEngine;
using Valve.VR;


public class Actions : MonoBehaviour
{
    public SteamVR_Action_Vector2 move;
    public static SteamVR_Action_Vector2 moveAction;

    public SteamVR_Action_Boolean jump;
    private static SteamVR_Action_Boolean jumpAction;

    public SteamVR_Action_Boolean tube;
    private static SteamVR_Action_Boolean tubeAction;
    
    public SteamVR_Action_Boolean menu;
    private static SteamVR_Action_Boolean menuAction;
    
    public SteamVR_Action_Boolean select;
    private static SteamVR_Action_Boolean selectAction;
    
    public SteamVR_Action_Boolean shoot;
    private static SteamVR_Action_Boolean shootAction;
    
    public SteamVR_Action_Pose pose;
    private static SteamVR_Action_Pose poseAction;
    
    private void Awake()
    {
        moveAction = move;
        jumpAction = jump;
        tubeAction = tube;
        menuAction = menu;
        shootAction = shoot;
        selectAction = select;
        poseAction = pose;
    }

    public static SteamVR_Action_Vector2 GetMoveAction()
    {
        return moveAction;
    }

    public static SteamVR_Action_Boolean GetJumpAction()
    {
        return jumpAction;
    }

    public static SteamVR_Action_Boolean GetTubeAction()
    {
        return tubeAction;
    }

    public static SteamVR_Action_Boolean GetMenuAction()
    {
        return menuAction;
    }
    
    public static SteamVR_Action_Boolean GetSelectAction()
    {
        return selectAction;
    }
    
    public static SteamVR_Action_Boolean GetShootAction()
    {
        return shootAction;
    }
    
    public static SteamVR_Action_Pose GetPoseAction()
    {
        return poseAction;
    }
}