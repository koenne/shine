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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.position = savedPos;
        areaPlayerScript.resetAndMove(savedUp, savedRight);
        areaPlayerScript.newAreaCode(savedUp, savedRight);
        animator.SetBool("isDead", false);
    }
    public void saveCheckPoint(Vector3 newPos, float up, float right)
    {
        savedPos = newPos;
        savedUp = up;
        savedRight = right;
    }
}
