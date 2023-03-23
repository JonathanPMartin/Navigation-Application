using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class GroupSettingsViewModel : ObservableObject
    {
        public async void Load()
        {
            User = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            Usergroup = await SQLService.GetGroup(User.group);
            Groupname = "You are currently a member of: "+Usergroup.name;

        }
        async void CalMeetingPoint()
        {

        }
        [ObservableProperty]
        string id;
        [ObservableProperty]
        string groupname;
        [ObservableProperty]
        Group usergroup;
        [ObservableProperty]
        Users user;
    }
}
