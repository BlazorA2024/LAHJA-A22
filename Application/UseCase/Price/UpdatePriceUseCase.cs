﻿using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.Repository.Payment;
using Domain.Repository.Plans;
using Domain.Repository.Price;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class UpdatePriceUseCase
    {
        private readonly IPriceRepository    repository;
        public UpdatePriceUseCase(IPriceRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PriceResponse>> ExecuteAsync(PriceUpdate request)
        {

            return await repository.UpdateAsync(request);

        }
    }
  







}
