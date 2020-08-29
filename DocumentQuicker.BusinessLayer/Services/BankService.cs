using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using DocumentQuicker.DataProvider;
using DocumentQuicker.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentQuicker.BusinessLayer.Services
{
    internal class BankService : IBankService
    {
        private readonly DocumentQuickerContext _documentQuickerContext;
        private readonly IMapper _mapper;

        public BankService(DocumentQuickerContext documentQuickerContext,
                               IMapper mapper)
        {
            _documentQuickerContext = documentQuickerContext ??
                                      throw new ArgumentNullException(nameof(_documentQuickerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<Bank> Create(Bank bankInfo)
        {
            var bankInfoEf = _mapper.Map<BankEf>(bankInfo);
            await _documentQuickerContext.BankInfos.AddAsync(bankInfoEf);
            await _documentQuickerContext.SaveChangesAsync();

            return _mapper.Map<Bank>(bankInfoEf);
        }

        public async Task<Bank> Update(Bank bankInfo)
        {
            var bankInfoEf = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == bankInfo.Id);
            if(bankInfoEf == null)
                throw new KeyNotFoundException($"Entity with : {bankInfo.Id} not found");

            bankInfoEf.BankDescription = bankInfo.Description;
            bankInfoEf.Bic = bankInfo.Bic;
            bankInfoEf.CorrAccount = bankInfo.CorrAccount;

            _documentQuickerContext.BankInfos.Update(bankInfoEf);
            await _documentQuickerContext.SaveChangesAsync();
            
            return _mapper.Map<Bank>(bankInfoEf);
        }

        public async Task<IList<Bank>> Get()
        {
            var result = await _documentQuickerContext.BankInfos.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).ToListAsync();

            return result.Select(x => _mapper.Map<Bank>(x)).ToList();
        }

        public async Task<IList<Bank>> Get(int count, int offset)
        {
            var result = await _documentQuickerContext.BankInfos.Where(x => x.IsActive)
                .OrderByDescending(x => x.EditDate).Skip(offset).Take(count).ToListAsync();
            
            return result.Select(x => _mapper.Map<Bank>(x)).ToList();
        }

        public async Task<Bank> Get(Guid id)
        {
            var bankInfo = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (bankInfo == null)
                throw new KeyNotFoundException($"Entity with : {id} not found");

            return _mapper.Map<Bank>(bankInfo);
        }

        public async Task<bool> Delete(Guid id)
        {
            var bankInfo = await _documentQuickerContext.BankInfos.FirstOrDefaultAsync(x => x.Id == id);
            if (bankInfo == null)
                throw new KeyNotFoundException($"Entity with : {id} not found");
            _documentQuickerContext.BankInfos.Remove(bankInfo);
            await _documentQuickerContext.SaveChangesAsync();
            return true;
        }
    }
}