# NativeScript-Vue Application

> A native application built with NativeScript-Vue

## Usage

``` bash
# Install dependencies
npm install

# Build for production
tns build <platform> --bundle

# Build, watch for changes and debug the application
tns debug <platform> --bundle

# Build, watch for changes and run the application
tns run <platform> --bundle
```

Before running the sample modify the app/components/TakePicture.vue . Replace the Azure Function url with your own url.
This componennt pushes the picture as Base64 string to Azure Function.

You can use the below code to create your Azure Function. Create a basic ``HttpTrigger`` function with below code.

```
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string imageString = data.ImageContent;

            log.LogInformation("Request Content Type");
            log.LogInformation(req.ContentType);
            log.LogInformation("Received Image Base64 String : " + imageString);

            var result = JsonConvert.SerializeObject(data.ImageContent);
            JsonResult resx = new JsonResult(result);
            return resx;
        }
    }
}
```


You can follow this post to Publish to Azure Function. 
https://baskarrao.wordpress.com/2018/10/19/day-5-nativescript-post-series/

Once published you can get your Azure Function url and replace it in the TakePicture Component. 


Take Picture Component uses NativeScript http plugin and Axios plugin to post the picture as Base64String.


StateSample Component uses Vuex to update the state for counter variable.
