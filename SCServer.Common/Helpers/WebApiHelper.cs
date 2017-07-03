using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SCServer.Common.Helpers
{   
    public class WebApiHelper : SCServer.Common.Helpers.IWebApiHelper  
    {
         public string Serviceurl { get { return Configurations.Api_URL() +"api/"; } }
         public string ApiName { get;set; }
         public string method { get; set; }
         public string ApiURL { get { return Configurations.Api_URL() + "api/" + ApiName + "/" + (!string.IsNullOrEmpty ( method) ? method + "/": "") ; } }
         public string AccessToken { get; set; }
         public bool Secure { get; set; }
        
         public WebApiHelper(string apiname,bool secure=true, string accesstoken="")
        {
            this.ApiName = apiname;
            this.Secure = secure;
            this.AccessToken = accesstoken;
        }

         public async Task<T> Get<T>(string method)
         {
             this.method = method;
            
            using (var httpClient = NewHttpClient())
            {
                T returnValue ;

                 
                var result = await httpClient.GetAsync(ApiURL);


                if (result.IsSuccessStatusCode)
                {
                    returnValue = await result.Content.ReadAsAsync<T>();
                }
                else
                {
                    var ex = WebApiException.CreateApiException(result);
                    throw ex;
                }


                return returnValue;
            }

        }
        public async Task<T> Post<T>(string method, object post_object=null )
        {
            this.method = method;
          
            using (var httpClient =  NewHttpClient())
            {
                var result = await httpClient.PostAsJsonAsync(ApiURL, post_object);
                T returnValue;
                if (result.IsSuccessStatusCode)
                {
                    returnValue = await result.Content.ReadAsAsync<T>();
                }
                else
                {
                    var ex = WebApiException.CreateApiException(result);
                    throw ex;
                }

                
                return returnValue;
            }

        }

        public async Task<MemoryStream> Post_GetFile(object post_object)
        {

            using (var httpClient = NewHttpClient())
            {
                
                int read = 0;

                var result = await httpClient.PostAsJsonAsync(ApiURL, post_object);
                MemoryStream returnValue = new MemoryStream();
                if (result.IsSuccessStatusCode)
                {
                    

                    var stream = await result.Content.ReadAsStreamAsync();
                    var buffer = new byte[2048];

                    while ( (read=await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                         
                        returnValue.Write(buffer, 0, read);
                    }
                }
                else
                {
                    var ex = WebApiException.CreateApiException(result);
                    throw ex;
                }


                return returnValue;
            }

        }
        public async Task<T> Put<T>(object post_object)
        {

            using (var httpClient = NewHttpClient())
            {
               


                var result = await httpClient.PutAsJsonAsync(ApiURL, post_object);
                T returnValue;
                if (result.IsSuccessStatusCode)
                {
                    returnValue = await result.Content.ReadAsAsync<T>();
                }
                else
                {
                    var ex = WebApiException.CreateApiException(result);
                    throw ex;
                }


                return returnValue;
            }

        }


        public async Task<T> Delete<T>(string id)
        {

            using (var httpClient = NewHttpClient())
            {


                var result = await httpClient.DeleteAsync(ApiURL + id);
                T returnValue;
                if (result.IsSuccessStatusCode)
                {
                    returnValue = await result.Content.ReadAsAsync<T>();
                }
                else
                {
                    var ex = WebApiException.CreateApiException(result);
                    throw ex;
                }


                return returnValue;
            }

        }


       

        public async Task<bool> UploadFiles(List<byte[]> files_memorystream, HttpFileCollectionBase filescollection, object parameters)
        {
            bool result = false;
            using (var httpClient = NewHttpClient())
            {
                    using (var content = new MultipartFormDataContent())
                    {
                        for (int i = 0; i < filescollection.Count; i++)
                            content.Add(new StreamContent(new MemoryStream(files_memorystream[i])),"file_"+ i , filescollection[i].FileName);
                        var stringContent = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                        stringContent.Headers.Add("Content-Disposition", "form-data; name=json");
                        content.Add(stringContent, "json");
                       
                        
                        var resTask = httpClient.PostAsync(ApiURL, content);  
                            resTask.Wait();
                            await resTask.ContinueWith(async responseTask =>
                            {
                                var res = await responseTask.Result.Content.ReadAsStringAsync();
                                result= bool.Parse(res);

                            }
                                );

                    }
                }
            return result;
        }
        protected HttpClient NewHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Serviceurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (this.Secure)
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",this.AccessToken );
            return client;
        }

        
    }
}