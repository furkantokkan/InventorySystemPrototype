using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 15f;
    private GameObject InventoryPanel;
    private GameObject InventoryButton;
    Vector3 movement;
    private float gravity = 15f;
    private Animator anim;
    bool isAttacking = false;
    bool playerTurning = false;
    CharacterController charControl;
    Rigidbody rb;
    Quaternion angle;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        InventoryPanel = GetComponent<EquipItemScript>().InventoryPanel;
        InventoryButton = GameObject.Find("Inventory_Button");
    }
    private void Start()
    {
        if (InventoryPanel.activeInHierarchy)
        {
            InventoryPanel.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame

    private void Update()
    {

        PlayerMove();
        PlayerAttack();
        PlayerTurn();
        InventoryPanelControl();
    }
    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking)
            {

                anim.SetTrigger("Attack1");

                isAttacking = true;
            }


        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isAttacking)
            {

                anim.SetTrigger("Attack2");

                isAttacking = true;
            }


        }
    }
    void PlayerTurn()
    {
        if (!isAttacking)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("TurnLeft", true);
                playerTurning = true;
                charControl.transform.Rotate(-transform.up, turnSpeed * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("TurnRight", true);
                playerTurning = true;
                charControl.transform.Rotate(transform.up, turnSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                playerTurning = false;
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
        }

    }
    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Strafe", h);


        if (isAttacking)
        {
            movement.Set(0f, -gravity * Time.deltaTime, 0.10f);
            anim.SetBool("TurnRight", false);
            anim.SetBool("TurnLeft", false);

        }
        else
        {
            if (!playerTurning)
            {
                movement.Set(h, -gravity * Time.deltaTime, v);

            }
        }

        movement = movement.normalized * Time.deltaTime * speed;



        charControl.Move(movement);
    }
    void InventoryPanelControl()
    {
        if (!InventoryPanel.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryPanel.SetActive(true);
                InventoryButton.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryPanel.SetActive(false);
                InventoryButton.SetActive(true);
            }
        }
    }

    void AttackAnimationOver()
    {
        isAttacking = false;
    }
}
