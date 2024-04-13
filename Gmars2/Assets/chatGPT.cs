using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
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
    [SerializeField] GameObject resBackground;
    [SerializeField] GameObject resText;
    [SerializeField] GameObject resPrompt;
    private string apiKey = "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";
    private string endpoint = "https://api.openai.com/v1/chat/completions";
    private string fetchedPrompt;
    public string responseString;




    public async void start()
    {
        readInput ReadInput = resPrompt.GetComponent<readInput>();
        if (ReadInput != null)
        {
            fetchedPrompt = ReadInput.prompt;
            Debug.Log("This is the prompt passed to OpenAI: " + fetchedPrompt);
        }
        else
        {
            Debug.LogError("The prompt given is empty\nValue null");
        }
        Debug.Log(fetchedPrompt);

        await chatRequest(ReadInput);
        
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
                "\"max_tokens\": 50" +
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
                    responseString = choice.message.content;
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
        displayResponse();
    }


    private void displayResponse()
    {
        Text textComponent = resText.GetComponent<Text>();
        textComponent.text = responseString;
    }

}
