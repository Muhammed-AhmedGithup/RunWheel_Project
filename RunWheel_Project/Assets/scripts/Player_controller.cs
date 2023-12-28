using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    private int D_line = 1;
   

    public float Addforce=10;
    public float dest_line=4;
    public float forward_speed;
    public float maxspeed;
    public float gravity = 20;
    public Animator animator_wheel;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player_Manager.isGamestart) return;

        if (forward_speed < maxspeed)
        {
            forward_speed += 0.1f * Time.deltaTime;
        }

        animator_wheel.SetBool("run", true);
        direction.z=forward_speed;
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            D_line--;
            if (D_line == -1) D_line = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }
        
        
        if (characterController.isGrounded)
        {
            animator_wheel.SetBool("jump", false);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }
        }
        else
        {
            direction.y -= gravity * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            D_line++;
            if (D_line == 3) D_line = 2;
        }

        var target_position=transform.position.z*transform.forward+transform.position.y*transform.up;

        if(D_line==0)
        {
            target_position += Vector3.left * dest_line;
        }
        if (D_line == 2)
        {
            target_position += Vector3.right * dest_line;
        }

        transform.position=target_position;
        characterController.center = characterController.center;
    }

    private void FixedUpdate()
    {
        if (!Player_Manager.isGamestart) return;
        characterController.Move(direction*Time.fixedDeltaTime);
    }

    private void jump()
    {
        animator_wheel.SetBool("jump", true);
        
        direction.y = Addforce;
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            FindObjectOfType<gameover_sound>().PlaySource();
            Player_Manager.gameover = true;
        }
    }

    private IEnumerator Slide()
    {
        animator_wheel.SetBool("slid", true);
        characterController.center = new Vector3(0, -0.5f, 0);
        characterController.height = 1;
        yield return new WaitForSeconds(1f);
        characterController.center = new Vector3(0,0, 0);
        characterController.height = 2;
        animator_wheel.SetBool("slid", false);

    }
}
