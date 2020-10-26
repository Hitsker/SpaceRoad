using UnityEngine;

public class StartGamePopUp : PopUp
{
    private void Update()
    {
        if (!Input.anyKey) return;
        
        GameManager.instance.gameController.ResumeGame();
        Hide(0);
    }
}
