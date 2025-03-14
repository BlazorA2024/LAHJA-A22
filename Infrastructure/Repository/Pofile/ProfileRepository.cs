﻿using AutoMapper;
using Domain.Entities.Billing.Response;
using Domain.Entities.Plans.Response;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Profile;
using Domain.ShareData;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.ApiClient.Profile;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.Billing.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Shared.Helpers;
using Shared.Settings;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ProfileRepository :IProfileRepository
{

    private readonly SeedsProfile seedsProfile;
    private readonly SeedsUsers seedsUsers;
    private readonly SeedsBillings seedsBillings;
    private readonly SeedsCreditCards seedsCreditCards;
    private readonly SeedsSubscriptionsData seedsSubscriptionsData;
    private readonly SeedsPlans seedsPlans;

    private readonly ProfileApiClient profileApiClient;
    private readonly ISessionUserManager _sessionUserManager;
    private readonly IMapper _mapper;
    private readonly ApplicationModeService appModeService;

	public ProfileRepository(SeedsProfile seedsProfile,
							 ProfileApiClient profileApiClient,
							IMapper mapper,
							ApplicationModeService appModeService,
							ISessionUserManager sessionUserManager,
							SeedsUsers seedsUsers,
							SeedsBillings seedsBillings,
							SeedsCreditCards seedsCreditCards,
							SeedsPlans seedsPlans,
							SeedsSubscriptionsData seedsSubscriptionsData)
	{
		this.seedsProfile = seedsProfile;
		this.profileApiClient = profileApiClient;
		_mapper = mapper;
		this.appModeService = appModeService;
		this._sessionUserManager = sessionUserManager;
		this.seedsUsers = seedsUsers;
		this.seedsBillings = seedsBillings;
		this.seedsCreditCards = seedsCreditCards;
		this.seedsPlans = seedsPlans;
		this.seedsSubscriptionsData = seedsSubscriptionsData;
	}

	public Task<Result<ProfileResponse>> CreateProfileAsync(ProfileRequest profileRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteProfileAsync(string profileId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ProfileUserResponse>> GetProfileUserAsync()
    {
        var response = await ExecutorAppMode.ExecuteAsync<Result<ProfileUserResponse>>(
             async () => await profileApiClient.GetProfileUserAsync(),
              async () => {
                  try
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email != null)
                      {
                          //var billing = seedsBillings.GetBillingDetailsByEmail(email);
                          //var cards = seedsCreditCards.GetCardDetailsByEmail(email);
                          var user = await seedsUsers.getUserByEmailAsync(email);
                          var subscriptionsPlans = seedsSubscriptionsData.getActiveSubscriptions(email);


                          //var bilRes = _mapper.Map<BillingDetailsResponseModel>(billing);
                          //var billingData = _mapper.Map<BillingDetailsResponse>(bilRes);

                          //var cardsRes = _mapper.Map<List<CardDetailsResponseModel>>(cards);
                          var subscriptionsPlansRes = _mapper.Map<List<SubscriptionResponse>>(subscriptionsPlans);
                          //var cardsData = _mapper.Map<List<CardDetailsResponse>>(cardsRes);

                          if (user != null)
                          {
                              var profile = new ProfileUserResponse
                              {
                                  Name = user?.Name ?? "",
                                  Email = user?.Email ?? "",
                                  PhoneNumber = user?.PhoneNumber ?? "",
                                  Image = user?.Image ?? "",
                            
                                  Subscription = new(),// subscriptionsPlansRes?.Count()>0? subscriptionsPlansRes.FirstOrDefault():null,
                              };
                              return Result<ProfileUserResponse>.Success(profile);
                          }

                      }

                      return Result<ProfileUserResponse>.Success();
                  }
                  catch (Exception e)
                  {
                      return Result<ProfileUserResponse>.Fail(e.Message);
                  }


              });

        return response;
    }
    public async Task<Result<ProfileResponse>> getProfileAsync()
    {

        var response = await ExecutorAppMode.ExecuteAsync<Result<ProfileResponse>>(
             async () => Result<ProfileResponse>.Success(),//await profileApiClient.getProfileAsync(),
              async () =>
              {

                  try
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email != null)
                      {
                          var billing = seedsBillings.GetBillingDetailsByEmail(email);
                          var cards = seedsCreditCards.GetCardDetailsByEmail(email);
                          var user = await seedsUsers.getUserByEmailAsync(email);
                          var subscriptionsPlans =  seedsSubscriptionsData.getActiveSubscriptions(email);


                          var bilRes = _mapper.Map<BillingDetailsResponseModel>(billing);
                          var billingData = _mapper.Map<BillingDetailsResponse>(bilRes);

                          var cardsRes = _mapper.Map<List<CardDetailsResponseModel>>(cards);
                          var subscriptionsPlansRes = _mapper.Map<List<SubscriptionResponse>>(subscriptionsPlans);
                          var cardsData = _mapper.Map<List<CardDetailsResponse>>(cardsRes);

                          if (user != null)
                          {
                              var profile = new ProfileResponse
                              {
                                  Name = user?.Name ?? "",
                                  Email = user?.Email ?? "",
                                  PhoneNumber = user?.PhoneNumber ?? "",
                                  Image = user?.Image ?? "",
                                  Active = user?.Active,
                                  CreditCards = cardsData,
                                  BillingDetails = billingData,
                                  Subscriptions = subscriptionsPlansRes,
                              };
                              return Result<ProfileResponse>.Success(profile);
                          }

                      }

                      return Result<ProfileResponse>.Success();
                  }
                  catch(Exception e)
                  {
                      return Result<ProfileResponse>.Fail(e.Message);
                  }

                      
              });

        if (response.Succeeded)
        {
            var result = (response.Data != null) ? _mapper.Map<ProfileResponse>(response.Data) : null;
            return Result<ProfileResponse>.Success(result);
        }
        else
        {
            return Result<ProfileResponse>.Fail(response.Messages);
        }
    }

    public Task<Result<ProfileResponse>> UpdateProfileAsync(ProfileRequest profileRequest)
    {
        throw new NotImplementedException();
    }
}
