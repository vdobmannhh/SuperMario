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
        poseAction = pose;
    }

    public static SteamVR_Action_Vector2 GetMoveAction()
    {
        return moveAction;
    }

    public static bool GetJumpAction()
    {
        return jumpAction.state && !PauseMenu.GameIsPaused;
    }

    public static bool GetTubeAction()
    {
        return tubeAction.state && !PauseMenu.GameIsPaused;
    }

    public static bool GetMenuAction()
    {
        return menuAction.GetStateUp(SteamVR_Input_Sources.Any);
    }

    public static bool GetShootAction()
    {
        return shootAction.GetStateUp(SteamVR_Input_Sources.Any) && !PauseMenu.GameIsPaused;
    }
    
    public static SteamVR_Action_Pose GetPoseAction()
    {
        return poseAction;
    }
    
    
}