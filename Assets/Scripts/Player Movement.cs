using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    Vector3 rotation;

    [SerializeField] float speed = 25f;
    [SerializeField] float xClampRange = 50f; 
    [SerializeField] float yClampRange = 50f;
    
    [SerializeField] float rotationPower = 100f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rotationSpeed = 10f;

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     ProccesTranslation();
     ProccesRotation();   
    }

    public void OnMove(InputValue value){
        movement = value.Get<Vector2>();
        
    }

    private void ProccesTranslation(){
        float xOffSet = movement.x * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffSet = movement.y * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos,0f);
    }

    private void ProccesRotation(){
        float pitch = -pitchPower * movement.y;
        float roll = -rotationPower * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch,0,roll);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
