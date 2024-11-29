using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;


    [SerializeField] float ControlRollFactor = 45f;
    [SerializeField] float ControlPitchFactor= 45f;
    [SerializeField] float rotationXSpeed = 10f;
    [SerializeField] float rotationYSpeed = 10f;
    Vector3 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float ClampedXPos = Mathf.Clamp(rawXPos, -xClampRange , xClampRange);
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float ClampedYPos = Mathf.Clamp(rawYPos, -yClampRange , yClampRange);
        transform.localPosition = new Vector3(ClampedXPos, ClampedYPos , 0f);
    }

    void ProcessRotation()
    {
        float roll = -ControlRollFactor * movement.x;
        float pitch = -ControlPitchFactor * movement.y;
        
        
        Quaternion targetRotationX = Quaternion.Euler(0f , 0f , roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation , targetRotationX , rotationXSpeed * Time.deltaTime);
        Quaternion targetRotationY = Quaternion.Euler(pitch , 0f , 0f );
        transform.localRotation = Quaternion.Lerp(transform.localRotation , targetRotationY , rotationYSpeed * Time.deltaTime);

    }
}
