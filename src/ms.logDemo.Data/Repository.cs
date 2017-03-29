using GenFu;
using ms.logDemo.Types.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ms.logBasic.Data
{
    public interface IContactRepository
    {
        List<ContactInfoDTO> GetList();
        ContactDTO GetItem(int id);
    }

    public class ContactRepository : IContactRepository
    {
        public List<ContactInfoDTO> GetList()
        {
            var data = GetContacts();
            return data;            
        }
        public ContactDTO GetItem(int id)
        {
            var item = Data().Where(x => x.Id == id).Select(x => x).SingleOrDefault();
            return item ==null ? new ContactDTO() : item;
        }

       private List<ContactDTO> Data()
        {
            return new List<ContactDTO>
            {
                new ContactDTO { Id = 1, Address1 = "11 Cambridge Way", Address2 = "Cambridge", PostCode = "CB1 1WW", Age = 25 },
                new ContactDTO  { Id = 2, Address1 = "12 Havehill Way", Address2 = "Haverhill", PostCode = "CB21 1WW", Age = 35 },
                new ContactDTO  { Id = 3, Address1 = "12 Barhill Way", Address2 = "Barhill", PostCode = "CB21 1WW", Age = 45 }
            };
        }

        private List<ContactInfoDTO> GetContacts()
        {
            Thread.Sleep(3000);
            var contacts = A.ListOf<ContactInfoDTO>(35);
            return contacts;
        }

        private ContactDTO GetContact()
        {
            var contact = A.New<ContactDTO>();
            return contact;
        }


    }
}
