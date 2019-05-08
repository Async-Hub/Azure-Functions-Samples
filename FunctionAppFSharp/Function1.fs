namespace FunctionAppFsharp

open Microsoft.Azure.WebJobs
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Mvc
open System.IO
open Newtonsoft.Json

module Function = 
    [<FunctionName("Function1")>]
    let Run([<HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)>] req: HttpRequest, log: ILogger) = 
        async {
            log.LogInformation("F# HTTP trigger function processed a request.");
            
            let name = req.Query.["name"]
            
            let streamReader = new StreamReader(req.Body);
            let! requestBody = streamReader.ReadToEndAsync() |> Async.AwaitTask

            let data = JsonConvert.DeserializeObject(requestBody);

            return new OkObjectResult("Function1")
         } |> Async.StartAsTask

