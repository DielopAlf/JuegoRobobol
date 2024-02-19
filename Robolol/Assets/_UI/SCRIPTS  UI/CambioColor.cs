using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CambioColor : MonoBehaviour
{

    public TextMeshProUGUI startText;

    public TextMeshProUGUI playText;
    public TextMeshProUGUI exitText;

    public TextMeshProUGUI optionsText;

    public TextMeshProUGUI creditText;
    public TextMeshProUGUI backText;
    public TextMeshProUGUI backCreditsText;

     public TextMeshProUGUI resetText;


    public void startTextYellow()
    {
        startText.color = Color.yellow;
    }

    public void startTextWhite()
    {
        startText.color = Color.white;
    }
    

    public void PlayTextYellow()
    {
        playText.color = Color.yellow;
    }

    public void PlayTextWhite()
    {
        playText.color = Color.white;
    }
    public void optionsTextYellow()
    {
      optionsText.color = Color.yellow;
    }

    public void optionsTextWhite()
    {
      optionsText.color = Color.white;
    }
    public void ExitTextYellow()
    {
        exitText.color = Color.yellow;
    }

    public void ExitTextWhite()
    {
        exitText.color = Color.white;
    }

    public void CreditTextYellow()
    {
        creditText.color = Color.yellow;
    }

    public void CreditTextWhite()
    {
        creditText.color = Color.white;
    }

    public void BackTextYellow()
    {
        backText.color = Color.yellow;
    }

    public void BackTextWhite()
    {
        backText.color = Color.white;
    }
      public void backCreditsTextYellow()
    {
        backCreditsText.color = Color.yellow;
    }

    public void backCreditsTextWhite()
    {
        backCreditsText.color = Color.white;
    }
      public void resetTextYellow()
    {
        resetText.color = Color.yellow;
    }

    public void resetTextWhite()
    {
       resetText.color = Color.white;
    }

}
