using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTextScript : MonoBehaviour
{
    TextMeshProUGUI storyText;
    List<string> sentences = new List<string>()
    {
        "The story of life is an open canvas.", "Each choice makes changes to that canvas.", "Some changes are easier than others.", "Though sometimes the harder path might have taught us something.",
        "Most of us are blind to each change as we make them.", "Because changes most often are ones to the lens through which we see our canvas.", "And not the canvas truly there.",
        "Our life is a piece of that larger canvas – a piece of art.", "Even if small in comparison to the whole of the canvas.", "We should treasure that small piece of art.",
        "Whichever way we choose to paint it.", "And strive to be happy with what we’ll have made at the end.", "As we all have just one canvas to paint."
    };
    int index = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        storyText = GetComponent<TextMeshProUGUI>();
        nextline();
    }

    public void nextline()
    {
        if (index < sentences.Count)
        {
            storyText.text = sentences[index];
            index++;
        }
    }
}
