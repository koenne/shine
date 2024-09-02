using UnityEngine;

public class playerCheckpointScript : MonoBehaviour
{
    public Vector3 savedPos;
    public float savedUp;
    public float savedRight;
    private Rigidbody2D rb;
    public areaPlayerScript areaPlayerScript;
    public bool uwu = false;
    public Animator animator;
    private CharacterController2D characterController;
    private bool gravity = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterController = FindAnyObjectByType<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uwu)
        {
            uwu = false;
            teleport();
        }
    }
    public void teleport()
    {
        rb.position = new Vector3(savedPos.x, savedPos.y + 0.5f, savedPos.z);
        rb.velocity = new Vector3(0, 0, 0);
        characterController.isGravityReversed = gravity;
        characterController.GravityChange(gravity);
        animator.SetBool("isDead", false);
    }
    public void saveCheckPoint(Vector3 newPos)
    {
        savedPos = newPos;
        gravity = characterController.isGravityReversed;
    }
}
