using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .5f)][SerializeField] private float coyoteTime = .1f;            // Tempo depois de cair de uma plataforma que o player ainda pode saltar
	[Range(0, .5f)][SerializeField] private float jumpBufferTime = .2f;
	private float coyoteTimeCounter;
	private float jumpBufferCounter;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	//separação em diferentes gameObjects requer isto
	private ICollisions collisions; // colisões do player
	private Rigidbody2D m_Rigidbody2D; // rigidbody deste player

	const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .1f; // Radius of the overlap circle to determine if the player can stand up
	
	private Vector3 m_Velocity = Vector3.zero;

	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
    public UnityEvent OnJumpingEvent;
    public UnityEvent OnFallingEvent;

    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
	public BoolEvent OnCrouchEvent;

	private bool m_wasCrouching = false;
    //private bool m_wasJumping = false;

    private void Awake()
	{
		if (this.collisions == null) 
		{
			this.collisions = SEntity.getObjRoot<SpEntity>(this.gameObject).GetComponentInChildren<ICollisions>();
		}
		if (this.m_Rigidbody2D == null) 
		{
			this.m_Rigidbody2D = this.collisions.GetComponent<Rigidbody2D>();
        }

		if (OnLandEvent == null)
        {
			OnLandEvent = new UnityEvent();
		}

		if (OnCrouchEvent == null)
        {
			OnCrouchEvent = new BoolEvent();
		}
	}

	//executa em cada frame!
	// fixedupdate s� executa x vezes por segundo
    private void Update()
    {
        if (!m_Grounded)
        {
            coyoteTimeCounter -= Time.deltaTime;
			jumpBufferCounter -= Time.deltaTime;
        }
		
		/*
		if (Input.GetButtonDown("Attack1")) 
		{
		Debug.DrawLine(m_GroundCheck.position - (Vector3.right * k_GroundedRadius), m_GroundCheck.position + (Vector3.right * k_GroundedRadius),Color.red,1f,false);
        Debug.DrawLine(m_GroundCheck.position - (Vector3.up * k_GroundedRadius), m_GroundCheck.position + (Vector3.up * k_GroundedRadius), Color.red, 1f, false);
		Debug.DrawLine(m_CeilingCheck.position - (Vector3.right * k_CeilingRadius), m_CeilingCheck.position + (Vector3.right * k_CeilingRadius),Color.blue,1f,false);
        Debug.DrawLine(m_CeilingCheck.position - (Vector3.up * k_CeilingRadius), m_CeilingCheck.position + (Vector3.up * k_CeilingRadius), Color.blue, 1f, false);
		}
		*/
    }

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		//Debug.Log("WasGrounded: " + wasGrounded);
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != collisions.gameObject)
			{
				//Debug.Log("Object : " + colliders[i].gameObject + " i = " + i);
				// sempre que está no chão:
				m_Grounded = true;
				coyoteTimeCounter = coyoteTime; // reinicia margem de erro para saltar, mesmo depois de cair das bordas
				if (!wasGrounded) // se n�o estava grounded antes, invoca eventos on land
				{
					//Debug.Log("onLand event: grounded? " + m_Grounded + " wasGrounded? " + wasGrounded);
					OnLandEvent.Invoke();
					//m_wasJumping = false;
				}
			}
		}
	}

	//move o eixo x com valor move (float), executa crouch, jump, ou stopJump
	public void Move(float move, bool crouch, bool jump)
	{

		// se jogador quer parar de crouch, verificar se se pode levantar
		if (m_wasCrouching && !crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            // or if the input is moving the player left and the player is facing right...
            if (move > 0 && !m_FacingRight || move < 0 && m_FacingRight)
			{
				// flip the player.
				Flip();
            }
		}

		// se quiser saltar, inicia a margem de salto permitida
		if (jump)
		{
			jumpBufferCounter = jumpBufferTime;
		}

		//se estiver sobre terreno, salta
		if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
		//&& !m_wasJumping) // antes era m_grounded && jump, agora � coyoteTime && jump
		{
			// Add a vertical force to the player.

			m_Grounded = false;
			//m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); // por adi��o ao y atual
			m_Rigidbody2D.velocity = new Vector3(m_Rigidbody2D.velocity.x, m_JumpForce * Time.fixedDeltaTime); // com o novo y s�
			coyoteTimeCounter = 0f; // j� saltou, n pode spammar salto vezes infinitas
			jumpBufferCounter = 0f; // j� saltou, n quer saltar instantaneamente outra vez
			OnJumpingEvent.Invoke(); // necess�rio para os casos em que se salta fora da borda

			//Debug.Log("Saltou e wasJumping: " + m_wasJumping);
		}
		//definir saltar ou cair nas anima��es
		if (!m_Grounded)
		{
			if (m_Rigidbody2D.velocity.y < -0.01)
			{
				OnFallingEvent.Invoke();
				//m_wasJumping = false; // se cair de fal�sia, n � considerado saltar
			}
			// � necess�rio porque bug ao saltar, deteta o chao enquanto sobe e mete o isJumping a false?!
            if (m_Rigidbody2D.velocity.y > 0.01)
            {
                OnJumpingEvent.Invoke();
            }
        }

		/*
		if (m_wasJumping && !jump)
		{
			Vector2 currVelocity = m_Rigidbody2D.velocity;
			m_Rigidbody2D.velocity = new Vector2(currVelocity.x, currVelocity.y * 0.6f);
		}
		*/
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = collisions.transform.localScale;
		theScale.x *= -1;
		collisions.transform.localScale = theScale;
	}

	//saber se player est� virado para a esquerda ou direita
	public bool getFacingRight()
	{
		return this.m_FacingRight;
	}

	public bool IsCrouching()
	{
		return this.m_wasCrouching; // n � bem se est� a dar crouch agora, mas acho que vai dar??
	}
}
