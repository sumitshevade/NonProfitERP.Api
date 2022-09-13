using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NonProfitERP.FunctionApp
{
    public static class TTBirthDayReminder
    {
        // This function will run on every day at 8 AM
        [FunctionName("TTBirthDayReminder")]
        public static void Run([TimerTrigger("0 10 9 * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //var message = JsonConvert.DeserializeObject<SendgridDataModel>(emailMessage);

            var executionRoot = context.FunctionAppDirectory;
            var jsonBytes = System.IO.File.ReadAllBytes(Path.Combine(executionRoot, "BirthData.json"));
            using var jsonDoc = JsonDocument.Parse(jsonBytes);

            var todaysBirthdays = jsonDoc.RootElement.EnumerateArray().Select(x => new
            {
                Name = x.GetProperty("name").ToString(),
                Email = x.GetProperty("email").ToString(),
                Birthdate = x.GetProperty("birthdate").ToString(),
            });

            foreach (var item in todaysBirthdays)
            {
                // this if is temporary
                if (item.Birthdate == DateTime.Today.ToShortDateString())
                {
                    var msg = new SendGridMessage();
                    msg.SetFrom(new EmailAddress("it@swaroopwardhinee.org", "Swa-roop Wardhinee"));
                    msg.SetSubject("Happy Birthday " + item.Name + "!");
                    msg.AddContent(MimeType.Html, "Hello " + item.Name + ",<br><br>" +
                        "<strong>Wish you a very happy birthday!</strong>");
                    msg.AddTo(new EmailAddress(item.Email, item.Name));

                    var client = new SendGridClient(Environment.GetEnvironmentVariable("SendGridAPIKey"));
                    var response = client.SendEmailAsync(msg).GetAwaiter().GetResult();

                    log.LogInformation("Email has been sent...!" + response.StatusCode);
                }
            }
        }
    }
}

// 7 -	<second> <minute> <hour> <day-of-month> <month> <day-of-week> <year>
// 6 - Seconds, Minutes, Hours, Day of Month, Month, Day of Week
// 0 0 8 1/1 * ? *
