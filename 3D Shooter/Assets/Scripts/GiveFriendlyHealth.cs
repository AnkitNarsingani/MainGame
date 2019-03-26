using UnityEngine;
using UnityEngine.UI;

public class GiveFriendlyHealth : MonoBehaviour {


    [SerializeField] float healthToGive = 30;
    [SerializeField] float cooldownTime = 5;
    private float timer = 0;
    private bool startTimer = false;
    Button healthButton;

    FriendlyAI friendlyAI;

	void Start ()
    {
        healthButton = GetComponent<Button>();
        friendlyAI = FindObjectOfType<FriendlyAI>();
	}
	
	void Update ()
    {
        if(startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                healthButton.interactable = true;
                timer = 0;
                startTimer = false;
            }
        }
	}

    public void GiveHealth(float health)
    {
        healthButton.interactable = false;
        friendlyAI.Givehealth(health);
        startTimer = true;
    }
}
