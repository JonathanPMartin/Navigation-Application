﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("Colour", "Colour")]
    public partial class GroupSettingsViewModel : ObservableObject
    {
        public async void Load()
        {
            User = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            Usergroup = await SQLService.GetGroup(User.group);
            Groupname = "You are currently a member of: "+Usergroup.name;
            Backgroundcolour = Color.FromRgba(Colour);

        }
        [RelayCommand]
        async void CalMeetingPoint()
        {
            var Point= await SQLService.calMeetingPoint(Usergroup.Id);
            var members= await SQLService.GroupMembers(Usergroup.Id);
            Groupname = members[0].Username;
            double Lat = 0;
            double Long = 0;
            for (int i = 0; i < members.Count; i++) {
                Locations Userlocaiton= await SQLService.GetLocation(members[i].Loc);
                Lat = Lat + Userlocaiton.Lat;
                Long= Long + Userlocaiton.Long;
            }
            Lat = Lat / members.Count;
            Long=Long/members.Count;
           
            Locations GroupLoaction = await SQLService.GetLocation(Usergroup.Loc);
            GroupLoaction.Lat = Lat;
            GroupLoaction.Long = Long;
            await SQLService.UpdateLocation(GroupLoaction);
            Groupname = $"{Lat} , {Long}";
            //double lat = Point[0];
            //double lon = Point[1];
            // Locations GroupLocation = await SQLService.GetLocation(Usergroup.Loc);
            //GroupLocation.Lat= lat;
            //GroupLocation.Long= lon;
            //await SQLService.UpdateLocation(GroupLocation);
            //Groupname = "Updated Location";
        }
        [RelayCommand]
        async void leaveGroup()
        {
            //if it is the owner who leaves, deletes the whole group
            if (Usergroup.owner == User.Id)
            {
                var members = await SQLService.GroupMembers(Usergroup.Id);
                if (members.Count > 1)
                {

                }
                else
                {
                    await SQLService.RemoveGroup(Usergroup.Id);
                    await SQLService.RemoveLocation(Usergroup.Loc);
                    User.group = -1;
                    await SQLService.UpdateUser(User);
                    await Shell.Current.GoToAsync($"{nameof(CreateJoinGroup)}?Id={Id}",
                new Dictionary<string, object>
                {
                   
                    ["Colour"] = Colour
                });
                }
            }
            else
            {
                User.group = -1;
                await SQLService.UpdateUser(User);
                await Shell.Current.GoToAsync($"{nameof(CreateJoinGroup)}?Id={Id}",
                new Dictionary<string, object>
                {
                   
                    ["Colour"] = Colour
                });
            }
        }
        [RelayCommand]
        async void directions()
        {
            Locations GroupLocation = await SQLService.GetLocation(Usergroup.Loc);
            var query=$"{GroupLocation.Lat} , {GroupLocation.Long}";
            //var query = Lat.Text + "," + Long.Text;
            query = "geo:0,0?q=" + query;
            

            await Launcher.OpenAsync(query);
        }
        [RelayCommand]
        async void GoHome()
        {
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={Id}",
                new Dictionary<string, object>
                {

                    ["Colour"] = Colour
                });
        }
        [RelayCommand]
        async void GoBack()
        {
            await Shell.Current.GoToAsync("..",
                new Dictionary<string, object>
                {
                    ["Id"] = Id,
                    ["Colour"] = Colour
                }); ;
        }
        [RelayCommand]
        async void GoSettigns()
        {

            await Shell.Current.GoToAsync($"{nameof(Settings)}?Id={Id}",
                new Dictionary<string, object>
                {

                    ["Colour"] = Colour
                });

        }
        [ObservableProperty]
        string id;
        [ObservableProperty]
        string groupname;
        [ObservableProperty]
        Group usergroup;
        [ObservableProperty]
        Users user;
        [ObservableProperty]
        string colour;
        [ObservableProperty]
        Color backgroundcolour;
    }
}
