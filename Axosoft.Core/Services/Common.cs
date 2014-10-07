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
    public class Common
    {
        private static Common _common = new Common();

        List<PickListItem> _statusItems;
        List<PickListItem> _priorityItems;
        List<PickListItem> _severityItems;
        List<PickListItem> _releaseTypeItems;
        List<PickListItem> _releaseStatusItems;
        List<PickListItem> _timeUnits;
        List<WorkFlow> _workFlows;

        private Common()
        {

        }

        private async Task<List<PickListItem>> LoadPickListItemsAsync(String pickListType)
        {
            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync(String.Format("picklist_{0}.cfg", pickListType), CreationCollisionOption.ReplaceExisting);

            return JsonConvert.DeserializeObject<List<PickListItem>>(await file.ReadAllTextAsync());
        }

        public async Task InitAsync()
        {
            _timeUnits = await LoadPickListItemsAsync("time_units");
            _statusItems = await LoadPickListItemsAsync("status");
            _priorityItems = await LoadPickListItemsAsync("priority");
            _severityItems = await LoadPickListItemsAsync("severity");
            _releaseTypeItems = await LoadPickListItemsAsync("release_types");
            _releaseStatusItems = await LoadPickListItemsAsync("release_status");

            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync("workflows.cfg", CreationCollisionOption.ReplaceExisting);
            _workFlows = JsonConvert.DeserializeObject<List<WorkFlow>>(await file.ReadAllTextAsync());
        }

        public static Common Instance { get { return _common; } }

        private async Task<List<PickListItem>> UpdatePickListItemsAsync(String pickListType)
        {
            var response = await AxoService.Instance.Call<PickListItemResponse>(String.Format("/picklists/{0}", pickListType));
            var pickListResponse = response.Response;

            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync(String.Format("picklist_{0}.cfg", pickListType), CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(pickListResponse.Items));
         
            return pickListResponse.Items;
        }

        private async Task UpdateWorkFlows()
        {
            var response = await AxoService.Instance.Call<Models.WorkFlowResponse>("/workflows");
            _workFlows = response.Response.WorkFlows;

            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync(String.Format("workflows.cfg", _workFlows), CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(_workFlows));

        }

        public async Task SyncAsync()
        {
            _timeUnits = await UpdatePickListItemsAsync("time_units");
            _statusItems = await UpdatePickListItemsAsync("status");
            _priorityItems = await UpdatePickListItemsAsync("priority");
            _severityItems = await UpdatePickListItemsAsync("severity");
            _releaseTypeItems = await UpdatePickListItemsAsync("release_types");
            _releaseStatusItems = await UpdatePickListItemsAsync("release_status");

        }

        public List<PickListItem> TimeUnits { get { return _timeUnits; } }
        public List<PickListItem> Status { get { return _statusItems; } }
        public List<PickListItem> Priority { get { return _priorityItems; } }
        public List<PickListItem> Severity { get { return _severityItems; } }
        public List<PickListItem> ReleaseTypes { get { return _releaseTypeItems; } }
        public List<PickListItem> ReleaseStatus { get { return _releaseStatusItems; } }
    }
}
