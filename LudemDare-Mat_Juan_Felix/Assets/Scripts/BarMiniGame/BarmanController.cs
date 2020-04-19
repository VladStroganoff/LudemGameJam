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


        private DrinkRecipe.Ingredient m_heldIngredient;

        void Update()
        {
            if(Input.GetButton("Horizontal"))
            {
                transform.position += new Vector3(Input.GetAxis("Horizontal") * m_speed * Time.deltaTime, 0, 0);
                if (BarmanAnimator.GetBool("IsRunning") == false)
                {
                    BarmanAnimator.SetBool("IsRunning", true);
                }
            }
            if (Input.GetButton("Vertical"))
            {
                transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * m_speed * Time.deltaTime);

                if (BarmanAnimator.GetBool("IsRunning") == false)
                {
                    BarmanAnimator.SetBool("IsRunning", true);
                }
            }


            if (Input.GetButtonUp("Vertical"))
            {
                BarmanAnimator.SetBool("IsRunning", false);

            }
        }

        private void PickupIngredient(DrinkRecipe.Ingredient ingredient)
        {
            m_heldIngredient = ingredient;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Blue")
            {
                HeldItem.SetItem(DrinkRecipe.Ingredient.Blue);
                m_heldIngredient = DrinkRecipe.Ingredient.Blue;
            }
            if (other.tag == "Pink")
            {
                HeldItem.SetItem(DrinkRecipe.Ingredient.Pink);
                m_heldIngredient = DrinkRecipe.Ingredient.Pink;
            }
            if (other.tag == "Red")
            {
                HeldItem.SetItem(DrinkRecipe.Ingredient.Red);
                m_heldIngredient = DrinkRecipe.Ingredient.Red;
            }
            if (other.tag == "Green")
            {
                HeldItem.SetItem(DrinkRecipe.Ingredient.Green);
                m_heldIngredient = DrinkRecipe.Ingredient.Green;
            }

            if (other.tag == "DrinkMixer" && m_heldIngredient != DrinkRecipe.Ingredient.Null)
            {
                m_bar.AddToMixer(m_heldIngredient);
                m_heldIngredient = DrinkRecipe.Ingredient.Null;
                HeldItem.RemoveFromHand();
                return;
            }

            if (other.tag == "CheckOrder")
            {
                m_bar.CheckOrder();
                return;
            }

            //FeedBackLog.FeedBack.Log("Holding: " + m_heldIngredient);

        }


    }
}