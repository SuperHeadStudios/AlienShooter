using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float enemyDetectionRange = 15f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private pAnimatorController controler;
    [SerializeField] private GameObject radialSkillEffectPrefab;
    [SerializeField] private float radialSkillEffectRadius = 15f;
    [SerializeField] private Joystick joystick;
    public bool isPc;

    private GameObject radialSkillEffect;

    private void Start()
    {
        if (radialSkillEffectPrefab != null)
        {
            radialSkillEffect = Instantiate(radialSkillEffectPrefab, transform.position, Quaternion.identity);
            radialSkillEffect.transform.SetParent(transform);
        }
    }

    private void FixedUpdate()
    {
        MoveControl();
    }

    private void Update()
    {
        UpdateRadialSkillEffectPosition();
    }

    private void MoveControl()
    {

        if (isPc)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            if (direction.magnitude > 0.001f)
            {
                characterController.Move(direction * moveSpeed * Time.smoothDeltaTime);
                RotateTowardsEnemy();
                controler.IsRun();
            }
            else
            {
                RotateTowardsEnemy();
                controler.IsIdleShoot();
            }
        }
        else
        {
            float moveHorizontal = joystick.Horizontal;
            float moveVertical = joystick.Vertical;
            Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            if (direction.magnitude > 0.001f)
            {
                characterController.Move(direction * moveSpeed * Time.smoothDeltaTime);
                RotateTowardsEnemy();
                controler.IsRun();
            }
            else
            {
                RotateTowardsEnemy();
                controler.IsIdleShoot();
            }
        }
    }
    private void RotateTowardsEnemy()
    {
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized;
            directionToEnemy.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.smoothDeltaTime);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= enemyDetectionRange)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void UpdateRadialSkillEffectPosition()
    {
        if (radialSkillEffect != null)
        {
            // Update the position of the radial skill effect
            radialSkillEffect.transform.position = transform.position + new Vector3(0, 0, radialSkillEffectRadius);
        }
    }
}
