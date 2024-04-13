using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
public class chatGPT : MonoBehaviour
{
    [SerializeField] GameObject resBackground;
    [SerializeField] GameObject resText;
    [SerializeField] GameObject resPrompt;
    private string apiKey = "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";
    private string endpoint = "https://api.openai.com/v1/chat/completions";
    private string fetchedPrompt = "Hello Chatgpt";
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
            // Construct the request data as a C# object
            var requestData = new
            {
                prompt = fetchedPrompt,
                max_tokens = 50
            };

            // Serialize the request data to JSON string
            string jsonData = JsonUtility.ToJson(requestData);

            // Create the HTTP request with JSON content
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            // Send the POST request to the endpoint
            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            Debug.Log(response);
            // Handle the response
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.Log("Response: " + responseBody);
                // Process the response data here
                responseString = responseBody;
            }
            else
            {
                Debug.LogError("Error: " + response.StatusCode);
            }
        }
        catch (HttpRequestException e)
        {
            if (e.Response != null && e.Response.Content != null)
            {
                string responseContent = await e.Response.Content.ReadAsStringAsync();
            Debug.LogError("Response Content: " + responseContent);
            }
    {

    }
        }
        finally
        {
            client.Dispose();
        }

    }


    private void displayResponse()
    {
        //resText = responseString;
    }

}
