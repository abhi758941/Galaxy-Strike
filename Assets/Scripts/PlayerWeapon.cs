using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDIstance = 100f;
    bool isFiring = false;
    void Start() 
    {
        Cursor.visible = false;    
    }
    private void Update() 
    {
        processFiring();
        moveCrosshair();
        moveTargetPoint();
        aimLasers();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void processFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isFiring;
        }
    }
    void moveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void moveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDIstance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void aimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - laser.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
