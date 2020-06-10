using System;
namespace Data.Driven.Design.Application.Entities
{
    public class CustumerEntity : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CustumerEntity()
        {
        }
    }
}
