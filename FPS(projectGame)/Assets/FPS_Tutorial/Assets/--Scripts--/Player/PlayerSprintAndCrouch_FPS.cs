using UnityEngine;

public class PlayerSprintAndCrouch_FPS : MonoBehaviour
{
    private PlayerMovement_FPS player_Movement;
    private PlayerFootsteps_FPS player_Footsteps;

    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;
    private bool is_Crouching;
    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f;
    private float walk_Volume_Max = 0.6f;
    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;

    private void Awake()
    {
        player_Movement = GetComponent<PlayerMovement_FPS>();
        look_Root = transform.GetChild(0);

        player_Footsteps = GetComponentInChildren<PlayerFootsteps_FPS>();
    }

    private void Start()
    {
        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }

    private void Update()
    {
        Sprint();
        Crouch();
    }

    private void Sprint()
    {
        // Only allow the character to sprint if not crouching.
        if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            player_Movement.speed = sprint_Speed;

            player_Footsteps.step_Distance = sprint_Step_Distance;
            player_Footsteps.volume_Min = sprint_Volume;
            player_Footsteps.volume_Max = sprint_Volume;
        }
        // If the sprint key is released, stop sprinting.
        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            player_Movement.speed = move_Speed;

            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.volume_Min = walk_Volume_Min;
            player_Footsteps.volume_Max = walk_Volume_Max;
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // If the character is crouched, stand up.
            if (is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f); // This is only changing the camera position.
                player_Movement.speed = move_Speed;
                is_Crouching = false;

                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Max = walk_Volume_Max;
            }
            // Else crouch.
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                player_Movement.speed = crouch_Speed;
                is_Crouching = true;

                player_Footsteps.step_Distance = crouch_Step_Distance;
                player_Footsteps.volume_Min = crouch_Volume;
                player_Footsteps.volume_Max = crouch_Volume;
            }
        }
    }
}