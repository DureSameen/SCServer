using System;
namespace SCServer.Common.Helpers
{
   public interface IWebApiHelper
    {
        string AccessToken { get; set; }
        string ApiName { get; set; }
        string ApiURL { get; }
        System.Threading.Tasks.Task<T> Delete<T>(string id);
        System.Threading.Tasks.Task<T> Get<T>(string method);
        string method { get; set; }
        System.Threading.Tasks.Task<System.IO.MemoryStream> Post_GetFile(object post_object);
        System.Threading.Tasks.Task<T> Post<T>(string method, object post_object = null);
        System.Threading.Tasks.Task<T> Put<T>(object post_object);
        bool Secure { get; set; }
        string Serviceurl { get; }
        System.Threading.Tasks.Task<bool> UploadFiles(System.Collections.Generic.List<byte[]> files_memorystream, System.Web.HttpFileCollectionBase filescollection, object parameters);
    }
}
