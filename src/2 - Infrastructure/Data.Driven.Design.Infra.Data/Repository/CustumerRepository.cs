using System;
using Data.Driven.Design.Application.Entities;
using Data.Driven.Design.Application.IRepository;
using Data.Driven.Design.Infra.Data.Contexts;

namespace Data.Driven.Design.Infra.Data.Repository
{
    public class CustumerRepository : BaseRepository<CustumerEntity>, ICustumerRepository
    {
        public CustumerRepository(Context context) : base(context)
        {
        }
    }
}
