using UnityEngine;

public class enemyGroundCheck : MonoBehaviour
{
    public EnemyScript EnemyScript;
    public shroomScript shroomScript;
    public bool isEnemy;
    public bool isShroom;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            if (isEnemy)
            {
                EnemyScript.noGround();
            }
            if (isShroom)
            {
                shroomScript.noGround();
            }

        }
    }
}
