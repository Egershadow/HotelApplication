using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace HotelClient.Model
{
    public class EntitiesService<EntityType> where EntityType : BaseEntity
    {
        public EntitiesService()
        {
        }

        public void AddEntity(EntityType entity, String address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2659/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync(address, entity).Result;//api/employee

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Entity Added");
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        public void DeleteEntity(EntityType entity, String address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2659/");

            String resultAddress = address + "/" + entity.Id;

            HttpResponseMessage response = client.DeleteAsync(resultAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Entity Deleted");
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        public void UpdateEntity(EntityType entity, String address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2659/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            String resultAddress = address;
            var response = client.PutAsJsonAsync(resultAddress, entity).Result;//api/employee

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Entity Updated");
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public IEnumerable<EntityType> GetAllEntities(String address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2659/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(address).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<EntityType>>().Result;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            return null;
        }

        public IEnumerable<EntityType> GetEntity(int id, String address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2659/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            String resultAddress = address + "/" + id;
            HttpResponseMessage response = client.GetAsync(resultAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<EntityType>>().Result;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            return null;
        }

    }
}
