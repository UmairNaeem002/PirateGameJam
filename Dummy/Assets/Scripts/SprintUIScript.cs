using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintUIScript : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Image sprintBarImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprintBar(PlayerMovementScript movement) 
    {
        //sprintBarImage.fillAmount = movement.RemainingStamina;
    }
}
