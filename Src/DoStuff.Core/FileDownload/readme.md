# File download 

From Angular you can use the umbRequestHelper to download a file. 
```
 umbRequestHelper.downloadFile(url)
```

this allows you to call your ApiController directly. 

## Controller 
from your controller you should return a HttpResponseMessage with your content and a few header fields that let the Umbraco request helper workout what you have sent back. 

the bulk of this response is : 

```
var response = new HttpResponseMessage
{
    Content = new ByteArrayContent(contentBytes)
    {
        Headers =
        {
            ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "repeating.txt"
            },
            ContentType = new MediaTypeHeaderValue("text/plain")
        }
    }
};
response.Headers.Add("x-filename", "repeating.txt");
return response;
```

## Html / Javascript

For this example the angular/html exists in the [dashboard controller](../App_Plugins/DoStuff.Dashboard)

The download call using the umbResourceHelper means everything
is handled for you, the user will get a save dialog once the 
server returns the file.

```
function download() {

    var message = 'Hello from here';
    var count = 100;

    vm.buttonState = 'busy';

    var url = Umbraco.Sys.ServerVariables.doStuffFileDownload.downloadService + 'DownloadText' + "?message=" + message + "&count=" + count;

    umbRequestHelper.downloadFile(url)
        .then(function (result) {
            vm.buttonState = 'success';
            notificationsService.success('Downloaded', 'File downloaded');
        }, function (error) {
            vm.buttonState = 'error';
            notificationsService.error('Error', 'Failed to download');
        });
}
```