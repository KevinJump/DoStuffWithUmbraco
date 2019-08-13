# File Upload

Umbraco 8 includes the [ngf-file-upload](https://github.com/danialfarid/ng-file-upload) library
and this combined with umbraco's inbuilt Upload service can be used to upload
files to anywhere on the site 

*n.b. the umb-file-upload directive only uploads to media*


## Controller 

you're controller needs to read in the request as MultiPartMime Content
and then use a provider to read the file contents. In this example we use 
a custom provider that inherits from `MultipartFormDataStreamProvider` mainly
so we can also get other form data from the upload

With this custom provider, we can read the content in and it will save the 
file to our desired location

```
if (!Request.Content.IsMimeMultipartContent())
    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

var uploadFolder = IOHelper.MapPath("~/App_Data/Temp/DoStuffUploads/");
Directory.CreateDirectory(uploadFolder);

var provider = new CustomMultipartFormDataStreamProvider(uploadFolder);
var result = await Request.Content.ReadAsMultipartAsync(provider);
var filename = result.FileData.First().LocalFileName;
```

## Html
For this example the angular/html exists in the [dashboard controller](../App_Plugins/DoStuff.Dashboard)

using the shipped nfg file upload directive we just need to add a few attributes
to the markup. 

```
<input id="dostufffilepicker"
        type="file"
        accept=""
        ngf-select
        ngf-model="filesHolder"
        ngf-change="vm.handleFiles($files, $event)"
        ngf-multipart="true" />

<label for="dostufffilepicker"
        class="btn btn-default">Choose File</label>

<umb-button action="vm.upload(vm.file)"
            type="button"
            label-key="general_upload"
            button-style="success"
            ng-if="vm.file != null"
            state="vm.buttonState"
            disabled="vm.buttonState == 'busy'">
</umb-button>

```

## Angular.

Handle files is fired when the user picks a file, we use it to set a value in
our controller for the file that has been picked
```
function handleFiles(files, event) {
    if (files && files.length > 0) {
        vm.file = files[0];
    }
}
```

---

The upload function takes the file, and uses the `Upload` Service to pass it 
onto the controller

```
function upload(file) {
    vm.buttonState = 'busy';
    Upload.upload({
        url: Umbraco.Sys.ServerVariables.doStuffFileUpload.uploadService + 'UploadFile',
        fields: {
            'someId': 1234
        },
        file: file
    }).success(function (data, status, headers, config) {
        vm.buttonState = 'success';
        notificationsService.success('Uploaded', data);
    }).error(function (data, status, headers, config) {
        vm.buttonState = 'error';
        notificationsService.error('Upload Failed', data);
    });
}
```