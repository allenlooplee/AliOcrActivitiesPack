using Cloud.Ocr.Activities;
using Cloud.Ocr.Contracts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Ocr.Models
{
    public class AliOcrClient : IOcrClient
    {
        public AliOcrClient(DataTable recognizerConfig)
        {
            Name = "Ali OCR";
            _recognizerConfig = recognizerConfig;
        }

        public string Name { get; }

        public async Task<JObject> RecognizeAsync(string recognizerName, string imagePath, Dictionary<string, object> options = null)
        {
            if (!FindRecognizer(_recognizerConfig, recognizerName, out var recognizerUrl, out var appCode))
            {
                throw new NotSupportedException($"{recognizerName} is not supported by {Name}.");
            }

            var imageData = File.ReadAllBytes(imagePath);
            var imageBase64 = Convert.ToBase64String(imageData);

            var body = new JObject(new JProperty("image", imageBase64));

            // When IdCardActivity is used, options will contain the key CardSide.
            // In this case, set configure\side for the ID card OCR API.
            var optionKey = nameof(IdCardActivity.CardSide);
            if (options != null && options.ContainsKey(optionKey))
            {
                var cardSideValue = (CardSide)options[optionKey];
                body.Add("configure",
                new JObject(
                    new JProperty("side", cardSideValue == CardSide.Front ? "face" : "back")));
            }

            var bodyData = Encoding.UTF8.GetBytes(body.ToString());

            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", "APPCODE " + appCode);
                client.Headers.Add("Content-Type", "application/json; charset=UTF-8");

                var response = await client.UploadDataTaskAsync(recognizerUrl, bodyData);
                var result = Encoding.UTF8.GetString(response);

                return JObject.Parse(result);
            }
        }

        private bool FindRecognizer(DataTable config, string recognizerName, out string recognizerUrl, out string appCode)
        {
            var found = config.AsEnumerable().FirstOrDefault(row => row.Field<string>("RecognizerName") == recognizerName);
            if (found != null)
            {
                recognizerUrl = found.Field<string>("RecognizerUrl");
                appCode = found.Field<string>("AppCode");

                return true;
            }
            else
            {
                recognizerUrl = null;
                appCode = null;

                return false;
            }
        }

        private DataTable _recognizerConfig;
    }
}
