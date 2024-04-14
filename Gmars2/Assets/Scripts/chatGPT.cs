using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}

[System.Serializable]
public class Choice
{
    public int index;
    public Message message;
    public object logprobs; // This can be of any type
    public string finish_reason;
}

[System.Serializable]
public class Usage
{
    public int prompt_tokens;
    public int completion_tokens;
    public int total_tokens;
}

[System.Serializable]
public class ResponseData
{
    public string id;
    public string obj;
    public long created;
    public string model;
    public string system_fingerprint;
    public Choice[] choices;
    public Usage usage;
}

public class chatGPT : MonoBehaviour

{

    [SerializeField] GameObject resText;
    [SerializeField] GameObject resPrompt;
    [SerializeField] GameObject scrollView;
    [SerializeField] GameObject downBtn;
    private string apiKey = "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";
    private string endpoint = "https://api.openai.com/v1/chat/completions";
    private string fetchedPrompt;
    public string responseMessage;
    private string previousPrompt = "";





    public async void StartGPT()
    {
        scrollView.SetActive(true);
        downBtn.SetActive(false);

        gameObject.GetComponent<Button>().interactable = false;
        readInput input = resPrompt.GetComponent<readInput>();

        if (input != null && input.ToString() != "")
        {
            fetchedPrompt = input.prompt;
            Debug.Log("This is the prompt passed to OpenAI: " + fetchedPrompt);
            previousPrompt = input.ToString();
            Debug.Log(fetchedPrompt);

            await chatRequest(input);
        }
        else
        {
            Debug.Log("The prompt given is empty\nValue null");
            gameObject.GetComponent<Button>().interactable = true;
        }

    }

    private async Task chatRequest(readInput ReadInput)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
        client.DefaultRequestHeaders.Add("User-Agent", "Unity");

        try
        {
            // Manually construct the JSON string
            string jsonContent = "{" +
                "\"model\": \"gpt-3.5-turbo\"," +
                "\"messages\": [{" +
                $"\"role\": \"system\"," +
                $"\"content\": \"{fetchedPrompt}\"" +
                "}]," +
                "\"max_tokens\": 100" +
                "}";

            StringContent stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Send the POST request to the endpoint
            HttpResponseMessage response = await client.PostAsync(endpoint, stringContent);
            // Handle the response
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.Log("Response: " + responseBody);
                // Process the response data here
                // Deserialize JSON data into ResponseData object
                ResponseData responseData = JsonUtility.FromJson<ResponseData>(responseBody);
                // Access and log the content of the message
                foreach (var choice in responseData.choices)
                {
                    responseMessage = choice.message.content;
                    Debug.Log("Content: " + choice.message.content);
                }

            }
            else
            {
                Debug.LogError("Error: " + response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError("HTTP request error: " + e.Message);
        }
        finally
        {
            client.Dispose();
        }
        await displayResponse();
    }


    private async Task displayResponse()
    {
        string messageDisplayed = "";
        TextMeshProUGUI textComponent = resText.GetComponent<TextMeshProUGUI>();
        textComponent.text = messageDisplayed;

        RectTransform rect = scrollView.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.size[0], 41f);
        rect.position = new Vector3(rect.position[0], 128f, rect.position[2]);

        foreach (char character in responseMessage)
        {
            messageDisplayed += character;
            textComponent.text = messageDisplayed;
            await Task.Delay(45);
        }
        gameObject.GetComponent<Button>().interactable = true;
        downBtn.SetActive(true);
    }
}


