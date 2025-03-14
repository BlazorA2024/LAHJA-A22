﻿using Application.Services.Profile;
using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Profile;
using LAHJA.ApplicationLayer.Profile;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Components.ProFileModel;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Data.UI.Templates.Profile;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Colors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAHJA.Data.UI.Templates.Profile
{
    //public class DataBuildUserProfile
    //{
    //    public string Id { get; set; }
    //    public string Email { get; set; }
    //}
    public interface IBuilderProfileComponent<T> : IBuilderComponents<T>
    {




        //public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }


    }

    public interface IBuilderProfileApi<T> : IBuilderApi<T>
    {


        Task<Result<ProfileResponse>> GetProfileAsync();
        Task<Result<ProfileUserResponse>> GetProfileUserAsync();

        Task<Result<ProfileResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<ProfileResponse>> UpdateAsync(T data);

        Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync();

        Task<ICollection<ProfileModelAiResponse>> ModelAisAsync();
        Task<ICollection<ProfileServiceResponse>> ServicesAsync();
        Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId);
        Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId);
        Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId);








        }

    public abstract class BuilderProfileApi<T, E> : BuilderApi<T, E>, IBuilderProfileApi<E>
    {

        public BuilderProfileApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        public abstract Task<Result<ProfileResponse>> CreateAsync(E data);


        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);


        public abstract Task<Result<ProfileUserResponse>> GetProfileUserAsync();
        public abstract Task<Result<ProfileResponse>> GetProfileAsync();
        public abstract Task<ICollection<ProfileModelAiResponse>> ModelAisAsync();
        public abstract Task<ICollection<ProfileServiceResponse>> ServicesAsync();
        public abstract Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId);
        public abstract Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId);

        public Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        {
            throw new NotImplementedException();
        }

        //public abstract Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId);
        public abstract Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync();

        public abstract Task<Result<ProfileResponse>> UpdateAsync(E data);



    }
    public class BuilderProfileComponent<T> : IBuilderProfileComponent<T>
    {


        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }



      



    }


    public class TemplateProfileShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderProfileApi<E> builderApi;
        private readonly IBuilderProfileComponent<E> builderComponents;
        public IBuilderProfileComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateProfileShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderProfileComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderProfileComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }


    public class BuilderProfileApiClient : BuilderProfileApi<ProfileClientService, DataBuildUserProfile>, IBuilderProfileApi<DataBuildUserProfile>
    {
        public BuilderProfileApiClient(IMapper mapper, ProfileClientService service) : base(mapper, service)
        {

        }

        public override Task<Result<ProfileResponse>> CreateAsync(DataBuildUserProfile data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<DeleteResponse>> DeleteAsync(DataBuildUserProfile dataId)
        {
            throw new NotImplementedException();
        }

        //public override  async Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        //{


        //    return await Service.SpaceSubscriptionAsync(subscriptionId, spaceId);
        //}



        public override  async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            return await Service.SpacesSubscriptionAsync(subscriptionId);
        }

        public override async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {

            return await Service.ServicesModelAiAsync(modelAiId);

        }


        public override  async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {


            return await Service.ModelAisAsync();

        }


        public override async Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {
            return await Service.SubscriptionsAsync();
        }

        public override Task<Result<ProfileResponse>> UpdateAsync(DataBuildUserProfile data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<ProfileResponse>> GetProfileAsync()
        {
            throw new NotImplementedException();
        }      
        
        public async override Task<Result<ProfileUserResponse>> GetProfileUserAsync()
        {
            return await Service.GetProfileUserAsync();
        }

        public override async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {
            return await Service.ServicesAsync();
        }



        //public override async Task<Result<ProfileResponse>> CreateAsync(DataBuildUserProfile data)
        //{
        //    var model = Mapper.Map<ProfileRequest>(data);
        //    var res = await Service.CreateAsync(model);
        //    if (res.Succeeded)
        //    {
        //        try
        //        {
        //            var map = Mapper.Map<ProfileResponse>(res.Data);
        //            return Result<ProfileResponse>.Success(map);

        //        }
        //        catch (Exception e)
        //        {
        //            return Result<ProfileResponse>.Fail();
        //        }
        //    }
        //    else
        //    {
        //        return Result<ProfileResponse>.Fail(res.Messages);
        //    }


        //}

        //public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildUserProfile data)
        //{

        //    var res = await Service.DeleteAsync(data.Id);
        //    if (res.Succeeded)
        //    {
        //        try
        //        {
        //            var map = Mapper.Map<DeleteResponse>(res.Data);
        //            return Result<DeleteResponse>.Success(map);

        //        }
        //        catch (Exception e)
        //        {
        //            return Result<DeleteResponse>.Fail();
        //        }
        //    }
        //    else
        //    {
        //        return Result<DeleteResponse>.Fail(res.Messages);
        //    }
        //}

        //public override async Task<Result<ProfileResponse>> GetProfileAsync()
        //{

        //    var res = await Service.GetProfileAsync();
        //    return res;
        //    //if (res.Succeeded)
        //    //{
        //    //    try
        //    //    {
        //    //        var map = Mapper.Map<ProfileResponse>(res.Data);
        //    //        return Result<ProfileResponse>.Success(map);

        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        return Result<ProfileResponse>.Fail();
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    return Result<ProfileResponse>.Fail(res.Messages);
        //    //}
        //}

        //public override async Task<Result<ProfileResponse>> UpdateAsync(DataBuildUserProfile data)
        //{
        //    var model = Mapper.Map<ProfileRequest>(data);
        //    var res = await Service.UpdateAsync(model);
        //    return res;
        //    //if (res.Succeeded)
        //    //{
        //    //    try
        //    //    {
        //    //        var map = Mapper.Map<ProfileResponse>(res.Data);
        //    //        return Result<ProfileResponse>.Success(map);

        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        return Result<ProfileResponse>.Fail();
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    return Result<ProfileResponse>.Fail(res.Messages);
        //    //}

        //}
    }


    public class TemplateProfile : TemplateProfileShare<ProfileClientService, DataBuildUserProfile>
    {

        public List<ProfileResponse> Profiles { get => _Profiles; }

        public List<string> Errors { get => _errors; }


         

        public TemplateProfile(
            IMapper mapper,
            AuthService AuthService,
            ProfileClientService client,
            IBuilderProfileComponent<DataBuildUserProfile> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnSubmitCreateProfile;
            this.BuilderComponents.SubmitUpdate = OnSubmitUpdateProfile;
            this.BuilderComponents.SubmitDelete = OnSubmitDeleteProfile;
            


            this.builderApi = new BuilderProfileApiClient(mapper, client);



        }


        public async Task<Result<List<DataBuildSpace>>> GetDataBuildSpaces(string subscriptionId)
        {

            try
            {
                var data = await builderApi.SpacesSubscriptionAsync(subscriptionId);

                var rev = mapper.Map<List<DataBuildSpace>>(data);

                return Result<List<DataBuildSpace>>.Success(rev);
            }
            catch (Exception e) {

                return Result<List<DataBuildSpace>>.Fail(e.Message);
            }


        }


        public async Task<Result<List<DataBuildUserSubscriptionInfo>>> GetDataBuildSubscriptions()
        {

            try
            {
                var data = await builderApi.SubscriptionsAsync();

                var rev = mapper.Map<List<DataBuildUserSubscriptionInfo>>(data);

                return  Result<List<DataBuildUserSubscriptionInfo>>.Success(rev);

            }catch(Exception e)
            {
                return Result<List<DataBuildUserSubscriptionInfo>>.Fail(e.Message);
            }


        }

        public  async Task<List<DataBuildUserModelAi>> GetDataBuildModelAis()
        {


            var data = await builderApi.ModelAisAsync();

            var rev = mapper.Map<List<DataBuildUserModelAi>>(data);

            return rev;

        }


        private List<ProfileResponse> _Profiles = new List<ProfileResponse>();

        private async Task<Result<DeleteResponse>> OnSubmitDeleteProfile(DataBuildUserProfile DataBuildUserProfile)
        {

              var response = await builderApi.DeleteAsync(DataBuildUserProfile);
            return response;

        }
        private async Task<Result<DataBuildUserProfile>> OnSubmitCreateProfile(DataBuildUserProfile DataBuildUserProfile)
        {

                var response = await builderApi.CreateAsync(DataBuildUserProfile);
            if (response.Succeeded)
            {
                var tm = mapper.Map<DataBuildUserProfile>(response.Data);
                return Result<DataBuildUserProfile>.Success(tm);
            }
            else
            {
                return Result<DataBuildUserProfile>.Fail(response.Messages);
            }


        }

        private async Task<Result<DataBuildUserProfile>> OnSubmitUpdateProfile(DataBuildUserProfile DataBuildUserProfile)
        {

                var response = await builderApi.UpdateAsync(DataBuildUserProfile);
            if (response.Succeeded)
            {
                var tm = mapper.Map<DataBuildUserProfile>(response.Data);
                return Result<DataBuildUserProfile>.Success(tm);
            }
            else
            {
                return Result<DataBuildUserProfile>.Fail(response.Messages);
            }


        }
        public async Task<Result<IEnumerable<SubscriptionPlanInfo>>> GetUserSubscriptionsPlanAsync()
        {
            var response = await builderApi.GetProfileAsync();
            if (response.Succeeded)
            {
                var data = mapper.Map<IEnumerable<SubscriptionPlanInfo>>(response.Data.Subscriptions);
                return Result<IEnumerable<SubscriptionPlanInfo>>.Success(data);
            }
            else
            {
                return Result<IEnumerable<SubscriptionPlanInfo>>.Fail(response.Messages);
            }
        }
        public async Task<Result<DataBuildUserProfile>> GetProfileAsync()
        {
            var response = await builderApi.GetProfileUserAsync();
            if (response.Succeeded)
            {
                   var data = mapper.Map<DataBuildUserProfile>(response.Data);
                   return  Result<DataBuildUserProfile>.Success(data);
            }
            else
            {
                return Result<DataBuildUserProfile>.Fail(response.Messages);
            }
           


        }

        public async Task<Result<DataBuildUserProfile>> GetProfileUserAsync()
        {
            var response = await builderApi.GetProfileUserAsync();
            if (response.Succeeded)
            {
                var data = mapper.Map<DataBuildUserProfile>(response.Data);
                return Result<DataBuildUserProfile>.Success(data);
            }
            else
            {
                return Result<DataBuildUserProfile>.Fail(response.Messages);
            }



        }
    }

}
