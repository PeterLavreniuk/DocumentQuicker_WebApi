using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Models;

namespace DocumentQuicker.BusinessLayer.Interfaces
{
    public interface IBankInfoService
    {
        Task<BankInfo> Create(string description, string bic, string corrAccount);
        Task<BankInfo> Edit(BankInfo info);
        Task<IList<BankInfo>> Get();
        Task<IList<BankInfo>> Get(int count) => Get(count: count, offset: 0);
        Task<IList<BankInfo>> Get(int count, int offset);
        Task<BankInfo> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}