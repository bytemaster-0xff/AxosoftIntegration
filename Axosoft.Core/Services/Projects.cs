using Axosoft.Core.Models;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Services
{
    public class Projects
    {
        private List<ProjectPortfolio> _portfolios;


        private List<Release> _releases;

        private static Projects _instance = new Projects();
        public static Projects Instance { get { return _instance; } }
       
        private async Task<List<ProjectPortfolio>> GetProjectsFromServerAsync()
        {
            var cfg = await Auth.Instance.GetExisitngAsync();

            var url = new Uri(String.Format("https://{0}/api/v2/projects",cfg.URL));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", cfg.AccessToken));
            var responseString = await client.GetStringAsync(url);
            var projectResponse = JsonConvert.DeserializeObject<ProjectsResponse>(responseString);

            return projectResponse.ProjectPortfolios;
        }

        private async Task<List<Release>> GetReleasesFromServerAsync()
        {
            var cfg = await Auth.Instance.GetExisitngAsync();

            var url = new Uri(String.Format("https://{0}/api/v2/releases", cfg.URL));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", cfg.AccessToken));
            var responseString = await client.GetStringAsync(url);
            Debug.WriteLine(responseString);
            var releaseResponse = JsonConvert.DeserializeObject<Axosoft.Core.Models.ReleasesResponse>(responseString);

            return releaseResponse.Releases;
        }

        public async Task<bool> InitAsync()
        {
            try
            {
                var fldr = FileSystem.Current.LocalStorage;
                var file = await fldr.GetFileAsync("portfolios.dat");
                var portfoliosStr = await file.ReadAllTextAsync();

                _portfolios = JsonConvert.DeserializeObject<List<ProjectPortfolio>>(portfoliosStr);

                file = await fldr.GetFileAsync("releases.dat");
                var releasesStr = await file.ReadAllTextAsync();

                _releases = JsonConvert.DeserializeObject<List<Release>>(releasesStr);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
       
        }

        private async void StorePortfoliosAsync(List<ProjectPortfolio> portfolios)
        {
            var portfolioJSON = JsonConvert.SerializeObject(portfolios);

            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync("portfolios.dat", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(portfolioJSON));
        }

        private async void StoreReleasesAsync(List<Release> releases)
        {
            var releaseJSON = JsonConvert.SerializeObject(releases);

            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync("releases.dat", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(releaseJSON));
        }

        public async Task<bool> SyncAsync()
        {
            try
            {
                _releases = await GetReleasesFromServerAsync();
                StoreReleasesAsync(_releases);

                _portfolios = await GetProjectsFromServerAsync();
                StorePortfoliosAsync(_portfolios);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<ProjectPortfolio> Portfolios
        {
            get { return _portfolios; }
        }

        public List<Release> Releases
        {
            get { return _releases; }
        }

    }
}
