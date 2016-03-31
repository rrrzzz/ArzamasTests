using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestFramework
{
    public static class Api
    {
        private static async Task<bool> EmailSubscribe(string email="kalandrill@yahoo.com")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiHost);
                var content = new FormUrlEncodedContent(new []
                {
                    new KeyValuePair<string, string>("email", email) 
                });
                var response = await client.PostAsync(Constants.Subscriptions, content);
                string responseString = await response.Content.ReadAsStringAsync();
                switch (responseString)
                {
                    case "error":
                        return false;
                    case "Спасибо, мы будем держать вас в курсе":
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static bool IsEmailSubscriptionSuccessful(string email = "kalandrill@yahoo.com") 
            => EmailSubscribe(email).Result;

        private static async Task<bool> SubmitFeedback(string name = "asd", string email = "asdsa@asd",
            string theme = "asdd", string msg = "asdasd")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiHost);
                var content = new FormUrlEncodedContent(new Dictionary <string, string>
                {
                    { "feedback[name]", name },
                    { "feedback[email]", email },
                    { "feedback[theme]", theme },
                    { "feedback[message]", msg },
                    { "commit", "Отправить" }
                });
                var response = await client.PostAsync(Constants.Feedback, content);
                var responseStatus = response.StatusCode.ToString() + " " + response.ReasonPhrase;
                return responseStatus == "422 Unprocessable Entity";
            }
        }

        public static bool IsFeedbackError(string name = "asd", string email = "asdsa@asd",
            string theme = "asdd", string msg = "asdasd") => SubmitFeedback(name, email, theme, msg).Result;
    }
}

