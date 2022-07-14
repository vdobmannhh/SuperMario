using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class FirstPersonController : MonoBehaviour
{

// ------------------------------------------------------------------------------------------------------------------------ global vars

	[Header("Player")] [Tooltip("Move speed of the character in m/s")]
	public float MoveSpeed = 5.5f;

	[Tooltip("Rotation speed of the character")]
	public float RotationSpeed = 1.5f;

	[Tooltip("Acceleration and deceleration")]
	public float SpeedChangeRate = 100f;

	[Tooltip("Force")] public float forceMultiplyer = 100f;

	[Space(10)] [Tooltip("The height the player can jump")]
	public float JumpHeight = 4.5f;

	[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
	public float Gravity = -15.0f;

	[Space(10)] [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
	public float JumpTimeout = 0.05f;

	[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
	public float FallTimeout = 0.15f;

	[Header("Player Detection")] [Tooltip("The Head of the Player")]
	public SphereCollider Head;

	[Tooltip("The Head of the Player")] public SphereCollider Feet;

	[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
	public bool Grounded = true;

	[Tooltip("Useful for rough ground")] public float Offset = 0.35f;

	[Tooltip("The radius of the head check.")]
	public float HeadRadius = 0.2f;

	[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
	public float GroundedRadius = 0.4f;

	[Tooltip("What layers the character uses as ground")]
	public LayerMask GroundLayers;

	// ----------------------------------------------------------- private vars

	// Movementspeed
	private float _speed;

	// vertical velocity
	private float _verticalVelocity;

	// 
	private float _terminalVelocity = 53.0f;

	// 
	private float _jumpTimeoutDelta;

	// 
	private float _fallTimeoutDelta;

	// 
	private CharacterController _controller;

	// 
	private bool headCollision = false;

	// 
	private bool headCollision2 = false;

	// 
	private float minStepOffset = 0.05f;

	// 
	private float defaultStepOffeset;

	// 
	private int powerUp = 0;

	// 
	private const float PLAYER_SCALE_UP = 1.2f;

	//
	public bool star = false;

	private const float FEET_OFFSET = 0.2f;

	private bool invincible = false;

	private float invincibleCounter = 0f;

	private const float INVINCIBLETIME = 1.5f;
	
	private bool invincibleMode = false;

	private bool dead = false;

	private Shoot shootScript;

	private Hands hands;
	
// ------------------------------------------------------------------------------------------------------------------------ Methods

	// Initialize
	private void Start()
	{
		SteamVR.Initialize();
		invincibleMode = OptionsMenu.ConvertIntToBool(PlayerPrefs.GetInt("invincibleMode"));
		AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
		Sounds.GetAudioSource(Sounds.AudioType.MainTheme).Play();
		_controller = GetComponent<CharacterController>();
		float HeadOffset = _controller.height - (HeadRadius - (GroundedRadius - Offset));
		var position = transform.position;
		Head.transform.position = new Vector3(position.x, position.y + HeadOffset, position.z);
		Head.radius = HeadRadius + 0.1f;
		Feet.transform.position = new Vector3(position.x, position.y + Offset - FEET_OFFSET, position.z);
		Feet.radius = GroundedRadius - 0.1f;

		defaultStepOffeset = _controller.stepOffset;

		// reset our timeouts on start
		_jumpTimeoutDelta = JumpTimeout;
		_fallTimeoutDelta = FallTimeout;

		shootScript = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Shoot>();
		hands = GameObject.FindGameObjectWithTag("Hands").GetComponent<Hands>();
	}

	// Frameupdate
	private void Update()
	{
		Move();
		InvincibleCheck();
	}
	
	// Update after Frameupdate
	private void LateUpdate()
	{
		GroundedCheck();
		JumpAndGravity();
	}

	// ----------------------------------------------------------- Movement

	// Is Player on Ground
	private void GroundedCheck()
	{
		Grounded = Physics.CheckSphere(Feet.transform.position + new Vector3(0, FEET_OFFSET, 0), GroundedRadius,
			GroundLayers, QueryTriggerInteraction.Ignore);
		headCollision = Physics.CheckSphere(Head.transform.position, HeadRadius, GroundLayers,
			QueryTriggerInteraction.Ignore);
	}

	// Movement
	private void Move()
	{
		float targetSpeed = MoveSpeed;


        //einkommentieren für kein vr

        //  if (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) == Vector2.zero)
        // {
        //     targetSpeed = 0.0f;
        // }
        // -----------------------

        //auskommentieren wenn kein VR
        Vector2 inputDirection = Actions.GetMoveAction().GetAxis(SteamVR_Input_Sources.Any);
	//	Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;
		
		if (inputDirection == Vector2.zero)
		{
			targetSpeed = 0.0f;
		}
		//-------------------------------

		float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

		float speedOffset = 0.1f;

		// accelerate or decelerate to target speed
		if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
		{
			_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed, Time.deltaTime * SpeedChangeRate);
			_speed = Mathf.Round(_speed * 1000f) / 1000f;
		}
		else
		{
			_speed = targetSpeed;
		}

        //einkommentieren wenn kein vr
        //
        // Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;
        // inputDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        //
        // if (inputDirection.magnitude > 1)
        // {
        //     inputDirection = inputDirection.normalized;
        // }
        //
        // _controller.Move(inputDirection * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
        //---------------------


        // auskommentieren wenn kein vr
        // Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;
        Vector3 resultMoveDirection = transform.right * inputDirection[0] + transform.forward * inputDirection[1];

        _controller.Move(resultMoveDirection * (_speed * Time.deltaTime) +
                         new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        //-----------------------------------
    }

	// Jump and Falling
	private void JumpAndGravity()
	{
		if (Grounded)
		{
			// reset the fall timeout timer
			_fallTimeoutDelta = FallTimeout;

			// stop our velocity dropping infinitely when grounded
			if (_verticalVelocity < 0.0f)
			{
				_verticalVelocity = -2f;
			}

			// Jump
			 if (Actions.GetJumpAction() && _jumpTimeoutDelta <= 0.0f)
			// if (Input.GetButtonDown("Jump") && _jumpTimeoutDelta <= 0.0f)
			 
			{
				// the square root of H * -2 * G = how much velocity needed to reach desired height
				_verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
				_controller.stepOffset = defaultStepOffeset;
				Sounds.GetAudioSource(Sounds.AudioType.Jump).Play();
			}

			// jump timeout
			if (_jumpTimeoutDelta >= 0.0f)
			{
				_jumpTimeoutDelta -= Time.deltaTime;
			}
		}
		else
		{
			// reset the jump timeout timer
			_jumpTimeoutDelta = JumpTimeout;

			// fall timeout
			if (_fallTimeoutDelta >= 0.0f)
			{
				_fallTimeoutDelta -= Time.deltaTime;
			}
		}

		// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
		if (_verticalVelocity < _terminalVelocity)
		{
			if (headCollision && !headCollision2)
			{
				_verticalVelocity = 0.0f;
				headCollision2 = true;
			}
			else if (!headCollision)
			{
				headCollision2 = false;
			}

			_verticalVelocity += Gravity * Time.deltaTime;
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit collision)
	{
		if (!invincible && collision.gameObject.CompareTag("Abyss") && dead == false)
		{
			dead = true;
			die();
		}
		
		if (collision.rigidbody == null)
		{
			return;
		}

		_controller.stepOffset = minStepOffset;
		Vector3 dir = collision.normal;
		Vector3 horizontalSpeed = new Vector3(dir.x, 0.0f, dir.z);
		collision.rigidbody.AddForce(-1.0f * horizontalSpeed * forceMultiplyer * Time.deltaTime, ForceMode.Impulse);

		if (!invincible && collision.gameObject.CompareTag("Goomba") &&
		    !collision.gameObject.GetComponent<Goomba>().dieing)
		{
			if ((Vector3.Angle(collision.normal, Vector3.up) < 20f) || invincibleMode)
			{

				collision.gameObject.GetComponent<Goomba>().die(Goomba.DeathTypes.DeathShrink);
			}
			else if (star)
            {
				collision.gameObject.GetComponent<Goomba>().die(Goomba.DeathTypes.DeathFlyAway);
			}
			else
			{
				PowerDown();
			}
		}
	}

	public void PowerUP(string item)
	{
		switch (item)
		{
			case "Mushroom":
				Sounds.GetAudioSource(Sounds.AudioType.Mushroom).Play();
				transform.localScale *= PLAYER_SCALE_UP;
				GroundedRadius *= PLAYER_SCALE_UP;
				HeadRadius *= PLAYER_SCALE_UP;
				powerUp = 1;
				hands.offsetFactor += new Vector3(0, 0.37f, 0); 
				break;
			case "Flower":
				Sounds.GetAudioSource(Sounds.AudioType.PowerUp).Play();
				powerUp = 2;
				break;
			case "Star":
				Sounds.GetAudioSource(Sounds.AudioType.StarTheme).Play();
				star = true;
				break;
			default:
				break;
		}
	}

	private void PowerDown()
	{
		switch (powerUp)
		{
			case 0:
				die();
				break;
			case 1:
				Sounds.GetAudioSource(Sounds.AudioType.PowerDown).Play();
				transform.localScale /= PLAYER_SCALE_UP;
				GroundedRadius /= PLAYER_SCALE_UP;
				HeadRadius /= PLAYER_SCALE_UP;
				hands.offsetFactor -= new Vector3(0, 0.37f, 0); 
				powerUp = 0;
				invincible = true;
				ChangeUi.setMushroomDisplay(false);
				break;
			case 2:
				Sounds.GetAudioSource(Sounds.AudioType.PowerDown).Play();
				powerUp = 1;
				invincible = true;
				shootScript.enabled = false;
				ChangeUi.setFireflowerDisplay(false);
				break;
			default:
				break;
		}
	}

	private void die()
	{
		print("die");
		invincible = true;
		Sounds.GetAudioSource(Sounds.AudioType.Waah).Play();
		
		GameObject.FindGameObjectWithTag("Fader").GetComponent<FadeOutController>()
			.FadeScreen(SceneManager.GetActiveScene().name);
		
		if (ChangeUi.life_count <= 0)
		{
			StartCoroutine(WaitThenResetLevel(3f, "Scene"));
			Cursor.lockState = CursorLockMode.None;
			ChangeUi.coin_count = 0;
			ChangeUi.life_count = 3;
		}
		else
		{
			ChangeUi.life_count--;
			StartCoroutine(WaitThenResetLevel(3f, "Scene"));
		}
		ChangeUi.resetUI();
		shootScript.enabled = false;
	}

	private IEnumerator WaitThenResetLevel(float seconds, string sceneName)
	{
		//Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(seconds);
		SceneManager.LoadScene(sceneName);
		dead = false;
		//Time.timeScale = 1;
	}

	private void InvincibleCheck()
	{
		if (invincible && !invincibleMode)
		{
			if (invincibleCounter > INVINCIBLETIME)
			{
				invincible = false;
				invincibleCounter = 0f;
			}
			else
			{
				invincibleCounter += Time.deltaTime;
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		var transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
		var transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
		if (Grounded) Gizmos.color = transparentGreen;
		else Gizmos.color = transparentRed;
		// 
	}

	public void SetInvincibleMode(bool mode)
    {
		invincibleMode = mode;
    }
}
	