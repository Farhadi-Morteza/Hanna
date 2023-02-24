
using System.Net.Http.Json;

namespace Client
{
    public abstract class ServiceBase : object
    {
        public ServiceBase(HttpClient http) : base()
        {
            JsonOptions =
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

            Http = http;
            //http.DefaultRequestHeaders

            BaseUrl = "https://localhost:7058";
            RequestUri = $"{ BaseUrl }/{ GetApiUrl() }";
        }

        protected abstract string GetApiUrl();

        protected string BaseUrl { get; set; }

        protected string RequestUri { get; set; }

        protected System.Net.Http.HttpClient Http { get; }

        protected System.Text.Json.JsonSerializerOptions JsonOptions { get; set; }

        protected virtual async System.Threading.Tasks.Task<O> ServiceBaseGetAsync<O>(string? query = null)
        {
            string myRequest = RequestUri;
            HttpResponseMessage response = null;


            try
            {
                if (string.IsNullOrWhiteSpace(query) == false)
                {
                    myRequest = $"{myRequest}/{query}";
                }

                response =
                    await Http.GetAsync(requestUri: myRequest);

                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(O);
                }
                else if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O? result =
                                await response.Content.ReadFromJsonAsync<O>();



                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<O> ServiceBasePostAsync<I, O>(I viewModel, string? query = null)
        {
            System.Net.Http.HttpResponseMessage response = null;
            string myRequest = RequestUri;

            try
            {
                if (string.IsNullOrWhiteSpace(query) == false)
                {
                    myRequest = $"{myRequest}/{query}";
                }
                response =
                    await Http.PostAsJsonAsync(requestUri: myRequest, value: viewModel);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        //System.Text.Json.JsonSerializerOptions jsonSerializerOptions =
                        //    new System.Text.Json.JsonSerializerOptions
                        //    {
                        //        MaxDepth = 5,
                        //        WriteIndented = true,
                        //        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                        //    };

                        //O result =
                        //    await response.Content.ReadFromJsonAsync<O>(options: jsonSerializerOptions);



                        // New Solution
                        O result =
                            await response.Content.ReadFromJsonAsync<O>();

                        return result;

                        // /New Solution

                        // Old Solution
                        //string data =
                        //	await response.Content.ReadAsStringAsync();

                        //O result =
                        //	System.Text.Json.JsonSerializer.Deserialize<O>(data);
                        // /Old Solution
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
                //response = null;
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<O> ServiceBasePutAsync<I, O>(I viewModel, string? query = null)
        {
            System.Net.Http.HttpResponseMessage response = null;
            string requestUri = RequestUri;

            try
            {
                if (string.IsNullOrWhiteSpace(query) == false)
                {
                    requestUri = $"{requestUri}/{query}";
                }

                response =
                    await Http.PutAsJsonAsync
                    (requestUri: requestUri, value: viewModel);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result =
                            await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<bool> ServiceBaseDeleteAsync<O>(string? query = null)
        {
            System.Net.Http.HttpResponseMessage? response = null;
            string myRequest = RequestUri;
            try
            {
                if (string.IsNullOrWhiteSpace(query) == false)
                {
                    myRequest = $"{myRequest}/{query}";
                }

                response =
                    await Http.DeleteAsync(requestUri: myRequest);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result =
                            await response.Content.ReadFromJsonAsync<O>();

                        return true;// result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return true;// default;
        }
    }
}
