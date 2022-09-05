using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2;
    public int groundLayer = 3;
    public float moveMultiplyer = 1;
    public float jumpMultiplyer = 1;
    public bool JumpKeyDown = false;

    public GameObject menuGroup;
    public Rigidbody2D playerRigidbody;

    public GameObject timeObject;
    public SpriteRenderer skin;
    public Animator anim;

    Vector2 prevPos = new Vector2(0,0);
    bool inMenu = false;
    bool grounded;
    float direction;

    void Update(){
        rb2.velocity = new Vector2(direction, rb2.velocity.y);
        if (grounded && JumpKeyDown) {
            rb2.velocity = new Vector2(rb2.velocity.x, 20f * jumpMultiplyer);
        }
        if (rb2.velocity.x == 0) {
            anim.SetBool("isMoving", false);
        } else if (direction > 1) {
            skin.flipX = false;
            anim.SetBool("isMoving", true);
        } else if (direction < 1) {
            skin.flipX = true;
            anim.SetBool("isMoving", true);
        }
        skin.flipY = false;
        if (grounded && JumpKeyDown && transform.position.y -1 > prevPos.y && transform.position.y +1 < prevPos.y) {
            skin.flipY = true;
        }
        prevPos = transform.position;
    }

    public void directionUpdate(InputAction.CallbackContext value) {
        if (!inMenu) {
            direction = value.ReadValue<float>() * 7 * moveMultiplyer;
        }
    }

    public void jump(InputAction.CallbackContext value) {
        if (!inMenu) {
            if (value.canceled) {
                JumpKeyDown = false;
            } else {
                JumpKeyDown = true;
            }
        }
    }

    public void restart(InputAction.CallbackContext value) {
        SceneManager.LoadScene("GameScene");
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.layer == groundLayer) {
            grounded = true;
            if (JumpKeyDown) {
                rb2.velocity = new Vector2(rb2.velocity.x, 20f * jumpMultiplyer);
            }
        } if (collision.gameObject.tag == "ded") {
            Debug.Log("Ded");
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == groundLayer){
            grounded = false;
        }
    }
    public void exit2Menu(InputAction.CallbackContext value) {
        if (value.performed) {
            inMenu = !inMenu;
            if (inMenu) {
                JumpKeyDown = false;
                direction = 0f;
                Debug.Log("Menu opened");
                menuGroup.SetActive(true);
                timeObject.SetActive(false);
                playerRigidbody.isKinematic = true;
                playerRigidbody.velocity = new Vector2(0,0);
            } else if(!inMenu) {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    public void restart() {
        SceneManager.LoadScene("GameScene");
    }
    public void exit() {
        SceneManager.LoadScene("MenuScene");
    }
}
