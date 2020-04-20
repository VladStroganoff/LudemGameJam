using UnityEngine;
using System.Collections;
using System.Xml;

namespace ProjectName.MiniGames.Bar
{
    public class BarmanController : MonoBehaviour
    {

        /// <summary>
        /// This is the controller for the barman 
        /// </summary>
        [Header("Movement Values")]
        [SerializeField]
        private float m_silenceRange;
        [SerializeField]
        private float m_speed;
        [Header("Assigned Values")]
        [SerializeField]
        private BarOrderQueue m_bar;
        public Animator BarmanAnimator;
        public ItemView HeldItem;

        private GameObject m_collidedObject;

        private DrinkRecipe.Ingredient m_heldIngredient;

        private float m_limitTop = -3.5f; // x
        private float m_limitBottom = 3.5f; // x
        private float m_limitLeft = -1.4f; // z
        private float m_limitRight = 0.1f; // z
        private Vector3 m_tempPos;

        void BoundryCheck()
        {
            m_tempPos = transform.position;

            if (m_tempPos.x > m_limitBottom)
            {
                m_tempPos.x = m_limitBottom;
            }
            if(m_tempPos.x < m_limitTop)
            {
                m_tempPos.x = m_limitTop;
            }

            if (m_tempPos.z > m_limitRight)
            {
                m_tempPos.z = m_limitRight;
            }
            if (m_tempPos.z < m_limitLeft)
            {
                m_tempPos.z = m_limitLeft;
            }

            transform.position = m_tempPos;
        }

        void Update()
        {
            BoundryCheck();

            if (Input.GetButton("Vertical"))
            {
                transform.position += new Vector3(Input.GetAxis("Vertical") * -m_speed * Time.deltaTime, 0, 0);
                if (BarmanAnimator.GetBool("IsRunning") == false)
                {
                    BarmanAnimator.SetBool("IsRunning", true);
                }
            }
            if (Input.GetButton("Horizontal"))
            {
                transform.position += new Vector3(0, 0, Input.GetAxis("Horizontal") * m_speed * Time.deltaTime);

                if (BarmanAnimator.GetBool("IsRunning") == false)
                {
                    BarmanAnimator.SetBool("IsRunning", true);
                }
            }


            if (Input.GetButtonUp("Horizontal"))
            {
                BarmanAnimator.SetBool("IsRunning", false);

            }


            if(m_collidedObject != null)
            {
                if (m_collidedObject.tag == "CheckOrder")
                {
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        m_bar.CheckOrder();

                        m_heldIngredient = DrinkRecipe.Ingredient.Null;
                        HeldItem.RemoveFromHand();

                        m_collidedObject = null;
                        return;
                    }
                }
                else
                {
                    if (m_collidedObject.tag == "Blue")
                    {
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            HeldItem.SetItem(DrinkRecipe.Ingredient.Blue);
                            m_heldIngredient = DrinkRecipe.Ingredient.Blue;

                            m_bar.AddToMixer(m_heldIngredient);
                            m_heldIngredient = DrinkRecipe.Ingredient.Null;
                            HeldItem.RemoveFromHand();

                            m_collidedObject = null;
                            return;
                        }
                    }
                    if (m_collidedObject.tag == "Pink")
                    {
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            HeldItem.SetItem(DrinkRecipe.Ingredient.Pink);
                            m_heldIngredient = DrinkRecipe.Ingredient.Pink;

                            m_bar.AddToMixer(m_heldIngredient);
                            m_heldIngredient = DrinkRecipe.Ingredient.Null;
                            HeldItem.RemoveFromHand();

                            m_collidedObject = null;
                            return;
                        }
                    }
                    if (m_collidedObject.tag == "Red")
                    {
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            HeldItem.SetItem(DrinkRecipe.Ingredient.Red);
                            m_heldIngredient = DrinkRecipe.Ingredient.Red;

                            m_bar.AddToMixer(m_heldIngredient);
                            m_heldIngredient = DrinkRecipe.Ingredient.Null;
                            HeldItem.RemoveFromHand();

                            m_collidedObject = null;
                            return;
                        }
                    }
                    if (m_collidedObject.tag == "Green")
                    {
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            HeldItem.SetItem(DrinkRecipe.Ingredient.Green);
                            m_heldIngredient = DrinkRecipe.Ingredient.Green;

                            m_bar.AddToMixer(m_heldIngredient);
                            m_heldIngredient = DrinkRecipe.Ingredient.Null;
                            HeldItem.RemoveFromHand();

                            m_collidedObject = null;
                            return;
                        }
                    }

                    // m_heldIngredient = DrinkRecipe.Ingredient.Null;
                    // HeldItem.RemoveFromHand();

                    /*if (m_collidedObject.tag == "DrinkMixer" && m_heldIngredient != DrinkRecipe.Ingredient.Null)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            m_bar.AddToMixer(m_heldIngredient);
                            m_heldIngredient = DrinkRecipe.Ingredient.Null;
                            HeldItem.RemoveFromHand();
                            return;
                        }
                    }*/
                }
            }
        }

        private void PickupIngredient(DrinkRecipe.Ingredient ingredient)
        {
            m_heldIngredient = ingredient;
        }

        private void OnTriggerEnter(Collider other)
        {
            m_collidedObject = other.gameObject;
            //FeedBackLog.FeedBack.Log("Holding: " + m_heldIngredient);
        }

        private void OnTriggerExit(Collider other)
        {
            m_collidedObject = null;
        }
    }
}