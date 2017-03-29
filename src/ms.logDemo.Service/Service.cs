using GenFu;
using ms.logBasic.Data;
using ms.logDemo.Types.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace ms.logBasic.Service
{
    public interface IContactService
    {
        List<ContactInfoDTO> GetList();
        ContactDTO GetItem(int id);
    }
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }
        
        public List<ContactInfoDTO> GetList()
        {
            //var data = AutoMapper.Mapper.Map<List<Contact>>(_repo.GetList());
            //return data;
            return _repo.GetList();
        }
        public ContactDTO GetItem(int id)
        {
            //var item = AutoMapper.Mapper.Map<Contact>(_repo.GetItem(id));
            //return item;
            return _repo.GetItem(id);
        }

       
    }
}
