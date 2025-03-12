﻿using AutoMapper;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.AuthorizationSession;
using Domain.Repository.AuthorizationSession;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.AuthorizationSession;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.Models.AuthorizationSession;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Repository.Base;
using Shared.Settings;

namespace Infrastructure.Repository.AuthorizationSession
{
    public class AuthorizationSessionRepository : BaseRepository<AuthorizationSessionApiClient>, IAuthorizationSessionRepository
    {
        public AuthorizationSessionRepository(IMapper mapper, ApplicationModeService appModeService, AuthorizationSessionApiClient apiClient) 
            : base(mapper, appModeService, apiClient)
        {

        }

        public async Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(AuthorizationWebRequest request) {
          
            var model = _mapper.Map<AuthorizationWebRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<AuthorizationSessionWebResponseModel>(
                 async () => await _apiClient.CreateAuthorizationSessionAsync(model),
                  async () => await _apiClient.CreateAuthorizationSessionAsync(model));

            return response;
        }
        public async Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest request) {
           
            var model = _mapper.Map<ValidateTokenRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<AuthorizationSessionCoreResponseModel>(
                 async () => await _apiClient.AuthorizationSessionAsync(model),
                  async () => await _apiClient.AuthorizationSessionAsync(model));

            return response;
        }
        public async Task ValidateSessionTokenAsync(string token) {

            
            await ExecutorAppMode.ExecuteAsync(
                 async () =>  _apiClient.ValidateSessionTokenAsync(token),
                  async () => _apiClient.ValidateSessionTokenAsync(token)
              );
        }
        public async Task EncryptFromWebAsync() {

                await ExecutorAppMode.ExecuteAsync(
                    async () => _apiClient.EncryptFromWebAsync(),
                    async () => _apiClient.EncryptFromWebAsync()
                );
        }
        public async Task EncryptFromCoreAsync(string sessionToken) {

            await ExecutorAppMode.ExecuteAsync(
                  async () => _apiClient.EncryptFromCoreAsync(sessionToken),
                  async () => _apiClient.EncryptFromCoreAsync(sessionToken)
              );
        }
        public async Task<DeleteResponse> DeleteAuthorizationSessionAsync(string sessionId) {

           return await ExecutorAppMode.ExecuteAsync<DeleteResponse>(
                    async () =>await  _apiClient.DeleteAuthorizationSessionAsync(sessionId),
                    async () => await _apiClient.DeleteAuthorizationSessionAsync(sessionId)
                );


        }
    }

}
